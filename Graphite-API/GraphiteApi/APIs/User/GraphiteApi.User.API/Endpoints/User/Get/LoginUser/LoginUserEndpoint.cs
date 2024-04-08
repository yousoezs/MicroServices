using FastEndpoints;
using GraphiteApi.User.BusinessLogic.Interfaces;
using GraphiteApi.User.BusinessLogic.Services.Extensions;
using GraphiteApi.User.DataAccess.DataModels;

namespace GraphiteApi.User.API.Endpoints.User.Get.LoginUser;

public class LoginUserEndpoint : Endpoint<LoginUserRequest, LoginUserResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public LoginUserEndpoint(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public override void Configure()
	{
		Get("/login");
		AllowAnonymous();
		Group<UserApiGroup>();
	}

	public override async Task HandleAsync(LoginUserRequest req, CancellationToken ct)
	{
		if (req.UserDto is null)
		{
			await SendErrorsAsync(statusCode: 400, cancellation: ct);
			return;
		}

		var response = await _unitOfWork.UserRepository.LoginAsync(req.UserDto.ConvertToModel());

		if (!response.Success)
		{
			await SendErrorsAsync(statusCode: 401, cancellation: ct);
			return;
		}

		await SendAsync(new() { UserDto = (response.Data ?? new UserModel()).ConvertToDto() }, 200, ct);
	}
}