namespace FizzBuzz.Api.Options
{
    public class FizzBuzzDatabaseOptions
    {
        const string sections = "FizzBuzzDatabase";

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}
