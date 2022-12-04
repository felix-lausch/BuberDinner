namespace BuberDinner.domain.Bill;

using BuberDinner.domain.Bill.ValueObjects;
using BuberDinner.domain.Common.Models;
using BuberDinner.domain.Common.ValueObjects;
using BuberDinner.domain.Dinner.ValueObjects;
using BuberDinner.domain.Guest.ValueObjects;
using BuberDinner.domain.Host.ValueObjects;
using System;

public class Bill : AggregateRoot<BillId>
{
    private Bill(
        BillId billId,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Money price,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(billId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public DinnerId DinnerId { get; }

    public GuestId GuestId { get; }

    public HostId HostId { get; }

    public Money Price { get; }

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public static Bill Create(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Money price)
    {
        return new(
            BillId.CreateUnique(),
            dinnerId,
            guestId,
            hostId,
            price,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
