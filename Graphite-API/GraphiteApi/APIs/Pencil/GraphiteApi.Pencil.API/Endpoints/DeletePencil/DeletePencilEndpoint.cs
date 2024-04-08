using FastEndpoints;
using GraphiteApi.Pencil.BusinessLogic.Interfaces;
using GraphiteApi.Pencil.BusinessLogic.Services;
using MongoDB.Bson;

namespace GraphiteApi.Pencil.API.Endpoints.DeletePencil;

public class DeletePencilEndpoint : Endpoint<DeletePencilRequest, DeletePencilResponse>
{
    private readonly IPencilUnitOfWork _unitOfWork;

    public DeletePencilEndpoint(IPencilUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public override void Configure()
    {
        Delete("/delete/{Id}");
        AllowAnonymous();
        Group<PencilApiGroup>();
    }

    public override async Task HandleAsync(DeletePencilRequest req, CancellationToken ct)
    {
        var result = await _unitOfWork.Repository
            .DeleteAsync(ObjectId.Parse(req.Id));

        if (!result.Success)
        {
            await SendErrorsAsync(
                statusCode: 400,
                cancellation: ct);
            return;
        }

        await _unitOfWork.SaveAsync();

        await SendAsync(
            new()
            {
                Message = result.Message
            },
            statusCode: 200,
            cancellation: ct
        );
    }
}
