using GraphiteApi.Domain.Commons.DataTransferObjects;

namespace GraphiteApi.Pencil.API.Endpoints.GetAllPencils;

public class GetAllPencilsResponse
{
    public IEnumerable<PencilDto>? Pencils { get; set; }
}