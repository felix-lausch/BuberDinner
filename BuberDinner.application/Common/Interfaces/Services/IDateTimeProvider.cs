﻿namespace BuberDinner.application.Common.Interfaces.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
