using FastEndpoints;
using GraphiteApi.User.BusinessLogic.Interfaces;
using GraphiteApi.User.BusinessLogic.Services.Extensions;
using GraphiteApi.User.DataAccess.DataModels;

namespace GraphiteApi.User.API.Endpoints.User.Post;

public class AddUserEndpoint : Endpoint<AddUserRequest, AddUserResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public AddUserEndpoint(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public override void Configure()
	{
		Post("/add");
		AllowAnonymous();
		Group<UserApiGroup>();
	}

	public override async Task HandleAsync(AddUserRequest req, CancellationToken ct)
	{
		if (req.UserDto is null)
		{
			await SendErrorsAsync(statusCode: 400, cancellation: ct);
			return;
		}

		var response = await _unitOfWork.UserRepository.AddAsync(req.UserDto.ConvertToModel());

		if (!response.Success)
		{
			await SendErrorsAsync(statusCode: 400, cancellation: ct);
			return;
		}

		await _unitOfWork.SaveAsync();
		await SendAsync(new() { UserDto = (response.Data ?? new UserModel()).ConvertToDto() }, 200, ct);
	}
}