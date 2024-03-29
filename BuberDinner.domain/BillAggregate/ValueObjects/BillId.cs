﻿namespace BuberDinner.domain.BillAggregate.ValueObjects;

using BuberDinner.domain.Common.Models;
using System;
using System.Collections.Generic;

public class BillId : ValueObject
{
    public BillId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static BillId CreateUnique()
    {
        return new BillId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
