﻿namespace BuberDinner.domain.Common.ValueObjects;

using BuberDinner.domain.Common.Models;
using System.Collections.Generic;

public sealed class Rating : ValueObject
{
    public float Value { get; private set; }

    public Rating(float value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}