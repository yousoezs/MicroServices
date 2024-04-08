using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GraphiteApi.Pencil.API.Endpoints.DeletePencil;

public class DeletePencilRequest
{
    [Required]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
}
