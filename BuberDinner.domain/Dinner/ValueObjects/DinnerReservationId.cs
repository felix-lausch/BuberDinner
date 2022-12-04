namespace BuberDinner.domain.Dinner.ValueObjects;

using BuberDinner.domain.Common.Models;
using System;
using System.Collections.Generic;

public class DinnerReservationId : ValueObject
{
    public Guid Value { get; }

    public DinnerReservationId(Guid value)
    {
        Value = value;
    }

    public static DinnerReservationId CreateUnique()
    {
        return new DinnerReservationId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}