using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FizzBuzz.Api.Models
{
    public class FizzBuzzModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Input { get; set; }

        public string Result { get; set; } = string.Empty;
    }
}
