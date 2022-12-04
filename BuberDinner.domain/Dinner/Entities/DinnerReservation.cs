namespace BuberDinner.domain.Dinner.Entities;

using BuberDinner.domain.Bill.ValueObjects;
using BuberDinner.domain.Common.Models;
using BuberDinner.domain.Dinner.ValueObjects;
using BuberDinner.domain.Guest.ValueObjects;
using System;

public class DinnerReservation : Entity<DinnerReservationId>
{
    private DinnerReservation(
        DinnerReservationId dinnerReservationId,
        int guestCount,
        DinnerReservationStatus status,
        GuestId guestId,
        BillId billId,
        DateTime? arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(dinnerReservationId)
    {
        GuestCount = guestCount;
        Status = status;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public int GuestCount { get; }

    public DinnerReservationStatus Status { get; }

    public GuestId GuestId { get; }

    public BillId BillId { get; }

    public DateTime? ArrivalDateTime { get; }

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public static DinnerReservation Create(
        int guestCount,
        DinnerReservationStatus status,
        GuestId guestId,
        BillId billId)
    {
        return new(
            DinnerReservationId.CreateUnique(),
            guestCount,
            status,
            guestId,
            billId,
            null,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
