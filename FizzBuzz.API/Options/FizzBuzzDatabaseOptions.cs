﻿using System.Diagnostics.CodeAnalysis;

namespace FizzBuzz.Api.Options
{
    [ExcludeFromCodeCoverage]
    public class FizzBuzzDatabaseOptions
    {
        const string sections = "FizzBuzzDatabase";

        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;

        public string CollectionName { get; set; } = string.Empty;
    }
}
