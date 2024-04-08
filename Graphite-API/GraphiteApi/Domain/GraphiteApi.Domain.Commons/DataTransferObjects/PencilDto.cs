using GraphiteApi.Domain.Commons.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GraphiteApi.Domain.Commons.DataTransferObjects;

public class PencilDto
{
	public string? Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public HardnessGrade Hardness { get; set; }

	public decimal Price { get; set; }

	public int StockQuantity { get; set; }
}
