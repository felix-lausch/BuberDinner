namespace BuberDinner.domain.MenuReviewAggregate;

using BuberDinner.domain.Common.Models;
using BuberDinner.domain.Common.ValueObjects;
using BuberDinner.domain.DinnerAggregate.ValueObjects;
using BuberDinner.domain.GuestAggregate.ValueObjects;
using BuberDinner.domain.HostAggregate.ValueObjects;
using BuberDinner.domain.MenuAggregate.ValueObjects;
using BuberDinner.domain.MenuReviewAggregate.ValueObjects;
using System;

public class MenuReview : AggregateRoot<MenuReviewId>
{
    private MenuReview(
        MenuReviewId menuReviewId,
        Rating rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public Rating Rating { get; }

    public string Comment { get; }

    public HostId HostId { get; }

    public MenuId MenuId { get; }

    public GuestId GuestId { get; }

    public DinnerId DinnerId { get; }

    public DateTime CreatedDateTime { get; }
    
    public DateTime UpdatedDateTime { get; }

    public static MenuReview Create(
        Rating rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId)
    {
        return new(
            MenuReviewId.CreateUnique(),
            rating,
            comment,
            hostId,
            menuId,
            guestId,
            dinnerId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
