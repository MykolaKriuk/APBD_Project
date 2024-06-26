using APBD_Projekt.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Projekt.Contexts;

public class IncManagerContext: DbContext
{

    public DbSet<Category> Categories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Firm> Firms { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PrivateClient> PrivateClients { get; set; }
    public DbSet<SoftwareDiscount> SoftwareDiscounts { get; set; }
    public DbSet<SoftwareSystem> SoftwareSystems { get; set; }
    public DbSet<SoftwareVersion> SoftwareVersions { get; set; }
    public DbSet<Worker> Workers { get; set; }
    
    protected IncManagerContext()
    {
    }

    public IncManagerContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PrivateClient>()
            .HasQueryFilter(p => !p.IsDeleted);

        modelBuilder.Entity<PrivateClient>()
            .Property(p => p.IsDeleted)
            .HasColumnName("Is_Deleted")
            .HasColumnType("bit")
            .HasDefaultValue(false);
        
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Client)
            .WithMany(c => c.Payments)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Contract)
            .WithMany(c => c.Payments)
            .HasForeignKey(p => p.ContractId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}