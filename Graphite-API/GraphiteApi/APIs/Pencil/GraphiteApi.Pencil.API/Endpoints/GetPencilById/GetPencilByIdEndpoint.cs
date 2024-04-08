using FastEndpoints;
using GraphiteApi.Pencil.BusinessLogic.Interfaces;
using GraphiteApi.Pencil.BusinessLogic.Services;
using MongoDB.Bson;

namespace GraphiteApi.Pencil.API.Endpoints.GetPencilById;

public class GetPencilByIdEndpoint : Endpoint<GetPencilByIdRequest, GetPencilByIdResponse>
{
    private readonly IPencilUnitOfWork _unitOfWork;

    public GetPencilByIdEndpoint(IPencilUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public override void Configure()
    {
        Get("/get/{Id}");
        AllowAnonymous();
        Group<PencilApiGroup>();
    }

    public override async Task HandleAsync(GetPencilByIdRequest req, CancellationToken ct)
    {
        var result = await _unitOfWork.Repository.GetByIdAsync(ObjectId.Parse(req.Id));

        if (!result.Success || result.Data is null)
        {
            await SendErrorsAsync(400, ct);
            return;
        }

        await SendAsync(
            new()
            {
                Pencil = PencilMapper.ToDto(result.Data)
            },
            statusCode: 200,
            cancellation: ct);
    }
}