namespace BuberDinner.domain.Common.ValueObjects;

using BuberDinner.domain.Common.Models;
using System.Collections.Generic;

public sealed class Rating : ValueObject
{
    public double Value { get; private set; }

    public Rating(double Value)
    {
        this.Value = Value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}