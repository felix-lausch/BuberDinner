
namespace BuberDinner.domain.Guest.ValueObjects;

using BuberDinner.domain.Common.Models;
using System;
using System.Collections.Generic;

public class GuestDinnerRatingId : ValueObject
{
    public Guid Value { get; }

    public GuestDinnerRatingId(Guid value)
    {
        Value = value;
    }

    public static GuestDinnerRatingId CreateUnique()
    {
        return new GuestDinnerRatingId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}