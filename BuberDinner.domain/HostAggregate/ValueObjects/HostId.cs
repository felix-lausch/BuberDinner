namespace BuberDinner.domain.HostAggregate.ValueObjects;

using BuberDinner.domain.Common.Models;
using System;
using System.Collections.Generic;

public class HostId : ValueObject
{
    public Guid Value { get; }

    public HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    public static HostId Create(string hostId)
    {
        return new HostId(new Guid(hostId));
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
