namespace BuberDinner.domain.MenuAggregate.ValueObjects;

using BuberDinner.domain.Common.Models;
using BuberDinner.domain.Menu.Entities;
using System;
using System.Collections.Generic;

public class MenuId : ValueObject
{
    public Guid Value { get; }

    public MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}