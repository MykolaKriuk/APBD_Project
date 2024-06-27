using APBD_Projekt.Contexts;
using APBD_Projekt.Services.ContractServices;
using APBD_Projekt.Services.FirmServices;
using APBD_Projekt.Services.PrivateClientService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IPrivateClientService, PrivateClientService>();
builder.Services.AddScoped<IFirmService, FirmService>();
builder.Services.AddScoped<IContractService, ContractService>();

builder.Services.AddDbContext<IncManagerContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();