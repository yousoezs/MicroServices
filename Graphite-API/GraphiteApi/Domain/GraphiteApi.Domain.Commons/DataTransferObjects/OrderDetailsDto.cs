namespace GraphiteApi.Domain.Commons.DataTransferObjects;

public class OrderDetailsDto
{
	public Guid Id { get; init; } = Guid.NewGuid();

	public PencilDto Product { get; set; } = null!;

	public OrderDto Order { get; set; } = null!;

	public int AmountOfProducts { get; set; }

	public DateTime CreatedDate { get; set; }

	public DateTime UpdatedDate { get; set; }
}