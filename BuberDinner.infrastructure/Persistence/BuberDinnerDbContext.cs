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
}
