namespace BuberDinner.domain.Menu.Entities;

using BuberDinner.domain.Common.Models;
using BuberDinner.domain.Menu.ValueObjects;
using System.Collections.Generic;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> items = new();

    private MenuSection(MenuSectionId id, string name, string description)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }

    public string Description { get; }

    public IReadOnlyList<MenuItem> Items => items.AsReadOnly();

    public static MenuSection Create(string name, string description)
    {
        return new(MenuSectionId.CreateUnique(), name, description);
    }
}
