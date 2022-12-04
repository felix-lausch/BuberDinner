namespace BuberDinner.domain.Guest.Entities;

using BuberDinner.domain.Common.Models;
using BuberDinner.domain.Common.ValueObjects;
using BuberDinner.domain.Dinner.ValueObjects;
using BuberDinner.domain.Guest.ValueObjects;
using BuberDinner.domain.Host.ValueObjects;

public class GuestDinnerRating : Entity<GuestDinnerRatingId>
{
    private GuestDinnerRating(
        GuestDinnerRatingId guestDinnerRatingId,
        HostId hostId,
        DinnerId dinnerId,
        Rating rating,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestDinnerRatingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public HostId HostId { get; }

    public DinnerId DinnerId { get; }

    public Rating Rating { get; }

    public DateTime CreatedDateTime { get; }
    
    public DateTime UpdatedDateTime { get; }

    public static GuestDinnerRating Create(
        HostId hostId,
        DinnerId dinnerId,
        Rating rating)
    {
        return new(
            GuestDinnerRatingId.CreateUnique(),
            hostId,
            dinnerId,
            rating,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
