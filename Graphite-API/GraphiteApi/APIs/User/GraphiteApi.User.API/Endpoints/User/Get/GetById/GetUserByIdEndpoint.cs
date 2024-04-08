using FastEndpoints;
using GraphiteApi.User.BusinessLogic.Interfaces;
using GraphiteApi.User.BusinessLogic.Services.Extensions;
using GraphiteApi.User.DataAccess.DataModels;

namespace GraphiteApi.User.API.Endpoints.User.Get.GetById;

public class GetUserByIdEndpoint : Endpoint<GetUserByIdRequest, GetUserByIdResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetUserByIdEndpoint(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public override void Configure()
	{
		Get("/getById/{Id}");
		AllowAnonymous();
		Group<UserApiGroup>();
	}

	public override async Task HandleAsync(GetUserByIdRequest req, CancellationToken ct)
	{
		if (!Guid.TryParse(req.Id, out var guid))
		{
			await SendErrorsAsync(statusCode: 400, ct);
			return;
		}

		var response = await _unitOfWork.UserRepository.GetByIdAsync(guid);

		if (!response.Success)
		{
			await SendErrorsAsync(statusCode: 204, ct);
			return;
		}

		await SendAsync(new() { UserDto = (response.Data ?? new UserModel()).ConvertToDto() }, 200, ct);
	}
}