using GraphiteApi.Domain.Commons.Enums;
using GraphiteApi.Domain.Commons.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace GraphiteApi.User.DataAccess.DataModels;

public class UserModel : IEntity<Guid>
{
	public Guid Id { get; init; } = Guid.NewGuid();

	public UserRole Role { get; set; }

	[EmailAddress,MaxLength(1000)] public string Email { get; set; } = null!;

	[MaxLength(1000)]public string Password { get; set; } = null!;

	public DateTime CreatedDate { get; set; }

	public DateTime UpdatedDate { get; set; }
}