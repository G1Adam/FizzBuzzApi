using System.Diagnostics.CodeAnalysis;

namespace FizzBuzz.Api.Options
{
    [ExcludeFromCodeCoverage]
    public class FizzBuzzDatabaseOptions
    {
        const string sections = "FizzBuzzDatabase";

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}
