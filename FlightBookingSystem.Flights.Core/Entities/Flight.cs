using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlightBookingSystem.Flights.Core.Entities
{
    public class Flight
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("FlightNumber")]
        public string FlightNumber { get; set; }

        [BsonElement("Origin")]
        public string Origin { get; set; }

        [BsonElement("Distination")]
        public string Distination { get; set; }

        [BsonElement("DepartureTime")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DepartureTime { get; set; }

        [BsonElement("ArrivalTime")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime ArrivalTime { get; set; }
    }
}