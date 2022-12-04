namespace BuberDinner.domain.Menu.ValueObjects;

using BuberDinner.domain.Common.Models;
using System;
using System.Collections.Generic;

public class MenuItemId : ValueObject
{
    public Guid Value { get; }

    public MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
