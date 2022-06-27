namespace BuberDinner.infrastructure.Services;

using BuberDinner.application.Common.Interfaces.Services;
using System;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
