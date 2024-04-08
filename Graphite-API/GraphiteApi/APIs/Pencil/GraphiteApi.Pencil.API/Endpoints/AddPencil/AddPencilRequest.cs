using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.Pencil.API.Endpoints.AddPencil;

public class AddPencilRequest
{
    public PencilDto? Pencil { get; set; }
}