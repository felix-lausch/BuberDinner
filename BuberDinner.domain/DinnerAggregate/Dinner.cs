namespace BuberDinner.domain.DinnerAggregate;

using BuberDinner.domain.Common.Models;
using BuberDinner.domain.Common.ValueObjects;
using BuberDinner.domain.DinnerAggregate.Entities;
using BuberDinner.domain.DinnerAggregate.ValueObjects;
using BuberDinner.domain.HostAggregate.ValueObjects;
using BuberDinner.domain.MenuAggregate.ValueObjects;
using System;
using System.Collections.Generic;

public class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<DinnerReservation> reservations = new();

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime? startedDateTime,
        DateTime? endedDateTime,
        DinnerStatus status,
        bool isPublic,
        int maxGuests,
        Money price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        DinnerLocation location,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string Name { get; }

    public string Description { get; }

    public DateTime StartDateTime { get; }

    public DateTime EndDateTime { get; }

    public DateTime? StartedDateTime { get; }

    public DateTime? EndedDateTime { get; }

    public DinnerStatus Status { get; }

    public bool IsPublic { get; }

    public int MaxGuests { get; }

    public Money Price { get; }

    public HostId HostId { get; }

    public MenuId MenuId { get; }

    public string ImageUrl { get; }

    public DinnerLocation Location { get; }

    public IReadOnlyList<DinnerReservation> Reservations => reservations.AsReadOnly();

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DinnerStatus status,
        bool isPublic,
        int maxGuests,
        Money price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        DinnerLocation location)
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            null,
            null,
            status,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
