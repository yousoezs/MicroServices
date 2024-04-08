using FastEndpoints;
using GraphiteApi.User.BusinessLogic.Interfaces;
using GraphiteApi.User.BusinessLogic.Services.Extensions;
using GraphiteApi.User.DataAccess.DataModels;

namespace GraphiteApi.User.API.Endpoints.User.Delete;

public class DeleteUserEndpoint : Endpoint<DeleteUserRequest, DeleteUserResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteUserEndpoint(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public override void Configure()
	{
		Delete("/delete/{Id}");
		AllowAnonymous();
		Group<UserApiGroup>();
	}

	public override async Task HandleAsync(DeleteUserRequest req, CancellationToken ct)
	{
		if (!Guid.TryParse(req.Id, out var guid))
		{
			await SendErrorsAsync(statusCode: 400, ct);
			return;
		}

		var response = await _unitOfWork.UserRepository.DeleteAsync(guid);

		if (!response.Success)
		{
			await SendErrorsAsync(statusCode: 204, ct);
			return;
		}

		await _unitOfWork.SaveAsync();
		await SendAsync(new() { UserDto = (response.Data ?? new UserModel()).ConvertToDto() }, 200, ct);
	}
}