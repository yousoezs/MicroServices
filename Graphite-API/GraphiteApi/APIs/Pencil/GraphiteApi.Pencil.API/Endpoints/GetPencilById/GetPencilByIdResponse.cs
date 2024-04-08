using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.Pencil.API.Endpoints.GetPencilById;

public class GetPencilByIdResponse
{
    public PencilDto? Pencil { get; set; }
}