namespace BuberDinner.domain.MenuAggregate.ValueObjects;

using BuberDinner.domain.Common.Models;

public class MenuId : ValueObject
{
    public MenuId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}