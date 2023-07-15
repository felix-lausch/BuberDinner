namespace BuberDinner.infrastructure.Persistence.Repositories;

using BuberDinner.application.Common.Interfaces.Persistence;
using BuberDinner.domain.MenuAggregate;
using System.Threading.Tasks;

public class MenuRepository : IMenuRepository
{
    private readonly BuberDinnerDbContext dbContext;

    public MenuRepository(BuberDinnerDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Add(Menu menu)
    {
        dbContext.Add(menu);
        await dbContext.SaveChangesAsync();
    }
}
