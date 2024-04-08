using FastEndpoints;
using GraphiteApi.Pencil.BusinessLogic.Interfaces;
using GraphiteApi.Pencil.BusinessLogic.Services;
using MongoDB.Bson;

namespace GraphiteApi.Pencil.API.Endpoints.AddPencil;

public class AddPencilEndpoint : Endpoint<AddPencilRequest, AddPencilResponse>
{
    private readonly IPencilUnitOfWork _unitOfWork;

    public AddPencilEndpoint(IPencilUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public override void Configure()
    {
        Post("/add");
        AllowAnonymous();
        Group<PencilApiGroup>();
    }

    public override async Task HandleAsync(AddPencilRequest req, CancellationToken ct)
    {
        if (req.Pencil is null)
        {
            await SendErrorsAsync(statusCode: 400, cancellation: ct);
            return;
        }

        var result = await _unitOfWork.Repository.AddAsync(PencilMapper.ToModel(req.Pencil));

        if (!result.Success)
        {
            await SendErrorsAsync(statusCode: 400, cancellation: ct);
            return;
        }

        await _unitOfWork.SaveAsync();

        await SendAsync(
            new AddPencilResponse{Data = req.Pencil, Message = result.Message}, 
            statusCode: 201,
            cancellation: ct);
    }
}
