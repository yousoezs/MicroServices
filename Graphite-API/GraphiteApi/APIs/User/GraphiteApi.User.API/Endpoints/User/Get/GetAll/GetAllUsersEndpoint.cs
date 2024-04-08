using FastEndpoints;
using GraphiteApi.User.BusinessLogic.Interfaces;
using GraphiteApi.User.BusinessLogic.Services.Extensions;
using GraphiteApi.User.DataAccess.DataModels;

namespace GraphiteApi.User.API.Endpoints.User.Get.GetAll;

public class GetAllUsersEndpoint : EndpointWithoutRequest<GetAllUsersResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetAllUsersEndpoint(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public override void Configure()
	{
		Get("/getAll");
		AllowAnonymous();
		Group<UserApiGroup>();
	}

	public override async Task HandleAsync(CancellationToken ct)
	{
		var response = await _unitOfWork.UserRepository.GetAllAsync();

		if (!response.Success)
		{
			await SendErrorsAsync(statusCode: 400, ct);
			return;
		}

		await SendAsync(new() { UserDtos = (response.Data ?? new List<UserModel>()).Select(x => x.ConvertToDto()) }, 200, ct);
	}
}