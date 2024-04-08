using System.ComponentModel.DataAnnotations;
using GraphiteApi.Domain.Commons.Enums;

namespace GraphiteApi.Domain.Commons.DataTransferObjects;

public class UserDto
{
	public Guid Id { get; init; } = Guid.NewGuid();

	public UserRole Role { get; set; }

	[EmailAddress, MaxLength(1000)] public string Email { get; set; } = null!;

	[MaxLength(1000)] public string Password { get; set; } = null!;

	public DateTime CreatedDate { get; set; }

	public DateTime UpdatedDate { get; set; }
}