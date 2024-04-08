using FastEndpoints;
using GraphiteApi.Pencil.BusinessLogic.Interfaces;
using GraphiteApi.Pencil.BusinessLogic.Services;

namespace GraphiteApi.Pencil.API.Endpoints.UpdatePencil;

public class UpdatePencilEndpoint : Endpoint<UpdatePencilRequest, UpdatePencilResponse>
{
    private readonly IPencilUnitOfWork _unitOfWork;

    public UpdatePencilEndpoint(IPencilUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public override void Configure()
    {
        Put("/update");
        AllowAnonymous();
        Group<PencilApiGroup>();
    }

    public override async Task HandleAsync(UpdatePencilRequest req, CancellationToken ct)
    {
        var result = await _unitOfWork.Repository.UpdateAsync(
            PencilMapper.ToModel(req.Pencil));

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
                Pencil = PencilMapper.ToDto(result.Data)
            },
            statusCode: 200,
            cancellation: ct
            );
    }
}
