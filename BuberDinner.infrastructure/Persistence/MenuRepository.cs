namespace BuberDinner.infrastructure.Persistence;

using BuberDinner.application.Common.Interfaces.Persistence;
using BuberDinner.domain.MenuAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> Menus = new();

    public async Task Add(Menu menu)
    {
        await Task.CompletedTask;

        Menus.Add(menu);
    }
}
