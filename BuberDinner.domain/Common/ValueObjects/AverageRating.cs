namespace BuberDinner.domain.Common.ValueObjects;

using BuberDinner.domain.Common.Models;
using System.Collections.Generic;

public sealed class AverageRating : ValueObject
{
    private AverageRating(double value, int ratingsCount)
    {
        Value = value;
        RatingsCount = ratingsCount;
    }

    public double Value { get; private set; }

    public int RatingsCount { get; private set; }

    public static AverageRating CreateNew(double rating = 0, int ratingCount = 0)
    {
        return new AverageRating(rating, ratingCount);
    }

    public void AddNewRating(Rating rating)
    {
        Value = ((Value * RatingsCount) + rating.Value) / ++RatingsCount;
    }

    public void RemoveRating(Rating rating)
    {
        Value = ((Value * RatingsCount) - rating.Value) / --RatingsCount;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return RatingsCount;
    }
}