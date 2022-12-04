namespace BuberDinner.domain.Host;

using BuberDinner.domain.Common.Models;
using BuberDinner.domain.Common.ValueObjects;
using BuberDinner.domain.Dinner.ValueObjects;
using BuberDinner.domain.Host.ValueObjects;
using BuberDinner.domain.Menu.ValueObjects;
using BuberDinner.domain.User.ValueObjects;
using System;
using System.Collections.Generic;

public class Host : AggregateRoot<HostId>
{
    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        string profileImageUrl,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImageUrl = profileImageUrl;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    private readonly List<MenuId> menuIds = new();

    private readonly List<DinnerId> dinnerIds = new();

    public string FirstName { get; }

    public string LastName { get; }

    public string ProfileImageUrl { get; }

    public AverageRating AverageRating { get; }
    
    public UserId UserId { get; }

    public IReadOnlyList<MenuId> MenuIds => menuIds.AsReadOnly();

    public IReadOnlyList<DinnerId> DinnerIds => dinnerIds.AsReadOnly();

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public static Host Create(
        string firstName,
        string lastName,
        string profileImageUrl,
        AverageRating averageRating,
        UserId userId)
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImageUrl,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
