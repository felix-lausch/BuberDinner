namespace BuberDinner.domain.Common.ValueObjects;

using BuberDinner.domain.Common.Models;
using System.Collections.Generic;

public sealed class Money : ValueObject
{
    public decimal Amount { get; private set; }

    public string Currency { get; private set; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
