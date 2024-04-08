using GraphiteApi.Domain.Commons.Enums;
using GraphiteApi.Domain.Commons.Interfaces;
using MongoDB.Bson;

namespace GraphiteApi.Pencil.DataAccess.Models;

public class PencilModel : IEntity<ObjectId>
{
    public ObjectId Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public HardnessGrade Hardness { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}