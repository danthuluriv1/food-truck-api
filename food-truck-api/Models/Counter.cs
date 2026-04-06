using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace food_truck_api.Models
{
    public class Counter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public long Count { get; set; }
    }
}
