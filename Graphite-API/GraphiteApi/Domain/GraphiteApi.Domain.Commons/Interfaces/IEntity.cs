namespace GraphiteApi.Domain.Commons.Interfaces;

public interface IEntity<out T>
{
	T Id { get; }
    DateTime CreatedDate { get; set; }
    DateTime UpdatedDate { get; set; }
}