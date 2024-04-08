using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.Pencil.API.Endpoints.AddPencil;

public class AddPencilResponse
{
    public PencilDto? Data { get; set; }
    public string? Message { get; set; }
}
