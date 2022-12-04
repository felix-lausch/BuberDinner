namespace BuberDinner.domain.MenuAggregate;

using BuberDinner.domain.Common.Models;
using BuberDinner.domain.Common.ValueObjects;
using BuberDinner.domain.DinnerAggregate.ValueObjects;
using BuberDinner.domain.HostAggregate.ValueObjects;
using BuberDinner.domain.MenuAggregate.Entities;
using BuberDinner.domain.MenuAggregate.ValueObjects;
using BuberDinner.domain.MenuReviewAggregate.ValueObjects;
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
        AverageRating averageRating,
        HostId hostId,
        List<MenuSection> sections,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuId)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        HostId = hostId;
        this.sections = sections;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string Name { get; }

    public string Description { get; }

    public AverageRating AverageRating { get; }

    public IReadOnlyList<MenuSection> Sections => sections.AsReadOnly();

    public HostId HostId { get; }

    public IReadOnlyList<DinnerId> DinnerIds => dinnerIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public static Menu Create(
        string name,
        string description,
        HostId hostId,
        List<MenuSection> sections)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            AverageRating.CreateNew(),
            hostId,
            sections,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
