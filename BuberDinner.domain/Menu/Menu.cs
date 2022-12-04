namespace BuberDinner.domain.Menu;

using BuberDinner.domain.Common.Models;
using BuberDinner.domain.Dinner.ValueObjects;
using BuberDinner.domain.Host.ValueObjects;
using BuberDinner.domain.Menu.Entities;
using BuberDinner.domain.Menu.ValueObjects;
using BuberDinner.domain.MenuReview.ValueObjects;
using System.Collections.Generic;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> sections = new();

    private readonly List<DinnerId> dinnerIds = new();
    
    private readonly List<MenuReviewId> menuReviewIds = new();

    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string Name { get; }

    public string Description { get; }

    public float AverageRating { get; }

    public IReadOnlyList<MenuSection> Sections => sections.AsReadOnly();

    public HostId HostId { get; }

    public IReadOnlyList<DinnerId> DinnerIds => dinnerIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public static Menu Create(
        string name,
        string description,
        HostId hostId)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
