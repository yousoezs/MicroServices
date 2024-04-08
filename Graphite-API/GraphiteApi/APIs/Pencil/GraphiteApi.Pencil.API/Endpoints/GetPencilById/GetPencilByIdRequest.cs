using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GraphiteApi.Pencil.API.Endpoints.GetPencilById;

public class GetPencilByIdRequest
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
}