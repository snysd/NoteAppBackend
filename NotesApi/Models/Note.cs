using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NotesApi.Models
{
    public class Note
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Alias { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string User { get; set; }
        public string Body { get; set; }
    }
}