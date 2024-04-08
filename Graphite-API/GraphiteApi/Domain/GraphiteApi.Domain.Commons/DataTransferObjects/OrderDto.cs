namespace GraphiteApi.Domain.Commons.DataTransferObjects;

public class OrderDto
{
	public Guid Id { get; set; } = Guid.NewGuid();

	public List<OrderDetailsDto> OrderDetails { get; set; } = new ();

	public UserDto UserId { get; set; } = null!;

	public DateTime CreatedDate { get; set; }

	public DateTime UpdatedDate { get; set; }
}