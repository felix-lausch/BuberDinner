namespace BuberDinner.domain.MenuAggregate.Entities;

using BuberDinner.domain.Common.Models;
using BuberDinner.domain.MenuAggregate.ValueObjects;
using System.Collections.Generic;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> items = new();

    private MenuSection(
        MenuSectionId id,
        string name,
        string description,
        List<MenuItem> items)
        : base(id)
    {
        Name = name;
        Description = description;
        this.items = items;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public IReadOnlyList<MenuItem> Items => items.AsReadOnly();

    public static MenuSection Create(string name, string description, List<MenuItem> items)
    {
        return new(MenuSectionId.CreateUnique(), name, description, items);
    }

#pragma warning disable CS8618
    private MenuSection()
    {
    }
#pragma warning restore CS8618
}
