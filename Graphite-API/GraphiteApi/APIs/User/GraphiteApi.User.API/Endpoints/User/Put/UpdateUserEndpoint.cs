using FastEndpoints;
using GraphiteApi.User.BusinessLogic.Interfaces;
using GraphiteApi.User.BusinessLogic.Services.Extensions;
using GraphiteApi.User.DataAccess.DataModels;

namespace GraphiteApi.User.API.Endpoints.User.Put;

public class UpdateUserEndpoint : Endpoint<UpdateUserRequest, UpdateUserResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public UpdateUserEndpoint(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public override void Configure()
	{
		Put("/update");
		AllowAnonymous();
		Group<UserApiGroup>();
	}

	public override async Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
	{
		if (req.UserDto is null)
		{
			await SendErrorsAsync(statusCode: 400, cancellation: ct);
			return;
		}

		var response = await _unitOfWork.UserRepository.UpdateAsync(req.UserDto.ConvertToModel());

		if (!response.Success)
		{
			await SendErrorsAsync(statusCode: 400, cancellation: ct);
			return;
		}

		await _unitOfWork.SaveAsync();
		await SendAsync(new() { UserDto = (response.Data ?? new UserModel()).ConvertToDto() }, 200, ct);
	}
}