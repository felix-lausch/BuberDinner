namespace BuberDinner.domain.Dinner.ValueObjects;

using BuberDinner.domain.Common.Models;
using System;
using System.Collections.Generic;

public class DinnerId : ValueObject
{
    public Guid Value { get; }

    public DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId CreateUnique()
    {
        return new DinnerId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}