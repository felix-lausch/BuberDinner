namespace BuberDinner.domain.DinnerAggregate.ValueObjects;

using BuberDinner.domain.Common.Models;
using System.Collections.Generic;

public class DinnerLocation : ValueObject
{
    public string Name { get; }

    public string Address { get; }

    public double Latitude { get; }

    public double Longitude { get; }

    public DinnerLocation(string name, string address, double latitude, double longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }
}
