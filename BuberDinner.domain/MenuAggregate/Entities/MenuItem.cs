namespace BuberDinner.domain.MenuAggregate.Entities;

using BuberDinner.domain.Common.Models;
using BuberDinner.domain.MenuAggregate.ValueObjects;

public sealed class MenuItem : Entity<MenuItemId>
{
    private MenuItem(MenuItemId id, string name, string description)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }

#pragma warning disable CS8618
    private MenuItem()
    {
    }
#pragma warning restore CS8618
}
