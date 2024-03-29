﻿namespace BuberDinner.domain.GuestAggregate.ValueObjects;

using BuberDinner.domain.Common.Models;

public class GuestId : ValueObject
{
    public Guid Value { get; }

    public GuestId(Guid value)
    {
        Value = value;
    }

    public static GuestId CreateUnique()
    {
        return new GuestId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
