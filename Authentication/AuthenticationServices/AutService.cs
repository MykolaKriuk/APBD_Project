using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APBD_Projekt.Authentication.AuthenticationDTOs;
using APBD_Projekt.Authentication.Helpers;
using APBD_Projekt.Contexts;
using APBD_Projekt.Exceptions;
using APBD_Projekt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace APBD_Projekt.Authentication.AuthenticationServices;

public class AutService(IncManagerContext context, IConfiguration configuration) : IAutService
{
    public async Task RegisterNewWorkerAsync(RegisterWorkerRequestModel requestModel, CancellationToken cancellationToken)
    {
        var hashedPassword = AuthenticationHelper.GetHashedPasswordAndSalt(requestModel.Password);
        var newWorker = new Worker
        {
            WorkerLogin = requestModel.Login,
            WorkerEmail = requestModel.Email,
            HashedPassword = hashedPassword.Item1,
            Salt = hashedPassword.Item2,
            RefreshToken = AuthenticationHelper.GenerateRefreshToken(),
            RefreshTokenExp = DateTime.Now.AddDays(1),
            WorkerRole = requestModel.Role
        };
        await context.Workers.AddAsync(newWorker, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<string> LoginWorkerAsync(LoginWorkerRequestModel requestModel, CancellationToken cancellationToken)
    {
        var worker = await context.Workers
            .FirstOrDefaultAsync(w => w.WorkerLogin == requestModel.Login, cancellationToken);
        if (worker is null)
        {
            throw new UnauthorizedWorkerException($"Login or password is incorrect");
        }

        var passwordHashFromDatabase = worker.HashedPassword;
        var currHashedPassword = AuthenticationHelper.GetHashedPasswordWithSalt(requestModel.Password, worker.Salt);
        if (passwordHashFromDatabase != currHashedPassword)
        {
            throw new UnauthorizedWorkerException("Login or password is incorrect");
        }

        var workerClaims = new[]
        {
            new Claim(ClaimTypes.Name, worker.WorkerLogin),
            new Claim(ClaimTypes.Role, worker.WorkerRole.ToLower())
        };
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        JwtSecurityToken token = new JwtSecurityToken(
            issuer: configuration["JWT:Issuer"],
            audience: configuration["JWT:Audience"],
            claims: workerClaims,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: creds
        );

        worker.RefreshToken = AuthenticationHelper.GenerateRefreshToken();
        worker.RefreshTokenExp = DateTime.Now.AddDays(1);
        await context.SaveChangesAsync(cancellationToken);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}