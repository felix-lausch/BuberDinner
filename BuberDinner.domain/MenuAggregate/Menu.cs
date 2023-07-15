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

    public string Name { get; private set; }

    public string Description { get; private set; }

    public AverageRating AverageRating { get; private set; }

    public IReadOnlyList<MenuSection> Sections => sections.AsReadOnly();

    public HostId HostId { get; private set; }

    public IReadOnlyList<DinnerId> DinnerIds => dinnerIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

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

#pragma warning disable CS8618
    private Menu()
    {
    }
#pragma warning restore CS8618
}
