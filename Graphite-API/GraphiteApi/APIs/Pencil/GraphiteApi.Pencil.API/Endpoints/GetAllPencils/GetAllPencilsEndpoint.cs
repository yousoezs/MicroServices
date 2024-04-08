using FastEndpoints;
using GraphiteApi.Pencil.BusinessLogic.Interfaces;
using GraphiteApi.Pencil.BusinessLogic.Services;

namespace GraphiteApi.Pencil.API.Endpoints.GetAllPencils;

public class GetAllPencilsEndpoint : EndpointWithoutRequest<GetAllPencilsResponse>
{
    private readonly IPencilUnitOfWork _unitOfWork;

    public GetAllPencilsEndpoint(IPencilUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public override void Configure()
    {
        Get("/get");
        AllowAnonymous();
        Group<PencilApiGroup>();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await _unitOfWork.Repository.GetAllAsync();

        if (!result.Success || result.Data is null)
        {
            await SendErrorsAsync(404, ct);
            return;
        }

        await SendAsync(new GetAllPencilsResponse()
        {
            Pencils = PencilMapper.ToDtoList(result.Data)
        }, cancellation: ct);
    }
}