namespace BuberDinner.infrastructure.Persistence;

using BuberDinner.domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

public class BuberDinnerDbContext : DbContext
{
    public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
