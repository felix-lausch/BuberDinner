namespace BuberDinner.domain.GuestAggregate;

using BuberDinner.domain.BillAggregate.ValueObjects;
using BuberDinner.domain.Common.Models;
using BuberDinner.domain.Common.ValueObjects;
using BuberDinner.domain.DinnerAggregate.ValueObjects;
using BuberDinner.domain.GuestAggregate.Entities;
using BuberDinner.domain.GuestAggregate.ValueObjects;
using BuberDinner.domain.MenuReviewAggregate.ValueObjects;
using BuberDinner.domain.UserAggregate.ValueObjects;

public class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> upcomingDinnerIds = new();

    private readonly List<DinnerId> pastDinnerIds = new();

    private readonly List<DinnerId> pendingDinnerIds = new();

    private readonly List<BillId> billIds = new();

    private readonly List<MenuReviewId> menuReviewIds = new();

    private readonly List<GuestDinnerRating> ratings = new();

    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImageUrl,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImageUrl = profileImageUrl;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string FirstName { get; }

    public string LastName { get; }

    public string ProfileImageUrl { get; }

    public AverageRating AverageRating { get; }

    public UserId UserId { get; }

    public IReadOnlyList<DinnerId> UpcomingDinnerIds => upcomingDinnerIds.AsReadOnly();

    public IReadOnlyList<DinnerId> PastDinnerIds => pastDinnerIds.AsReadOnly();

    public IReadOnlyList<DinnerId> PendingDinnerIds => pendingDinnerIds.AsReadOnly();

    public IReadOnlyList<BillId> BillIds => billIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => menuReviewIds.AsReadOnly();

    public IReadOnlyList<GuestDinnerRating> Ratings => ratings.AsReadOnly();

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImageUrl,
        AverageRating averageRating,
        UserId userId)
    {
        return new(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImageUrl,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
