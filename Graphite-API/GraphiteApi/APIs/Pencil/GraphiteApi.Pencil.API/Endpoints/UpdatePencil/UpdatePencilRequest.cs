using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.Pencil.API.Endpoints.UpdatePencil;

public class UpdatePencilRequest
{
    public PencilDto Pencil { get; set; } = new();
}