using GraphiteApi.Domain.Commons.DataTransferObjects;
using GraphiteApi.Pencil.DataAccess.Models;
using MongoDB.Bson;

namespace GraphiteApi.Pencil.BusinessLogic.Services;

public static class PencilMapper
{
    public static PencilModel ToModel(PencilDto pencilDto)
    {
        var pencilId = pencilDto.Id is null ? 
            ObjectId.GenerateNewId() : 
            ObjectId.Parse(pencilDto.Id);

        var pencilModel = new PencilModel
        {
            Id = pencilId,
            Name = pencilDto.Name,
            Description = pencilDto.Description,
            Hardness = pencilDto.Hardness,
            Price = pencilDto.Price,
            StockQuantity = pencilDto.StockQuantity
        };

        return pencilModel;
    }

    public static PencilDto ToDto(PencilModel pencilModel)
    {

        var pencilDto = new PencilDto
        {
            Id = pencilModel.Id.ToString(),
            Name = pencilModel.Name,
            Description = pencilModel.Description,
            Hardness = pencilModel.Hardness,
            Price = pencilModel.Price,
            StockQuantity = pencilModel.StockQuantity
        };

        return pencilDto;
    }

    public static IEnumerable<PencilDto> ToDtoList(IEnumerable<PencilModel> pencilModels)
    {
        var pencilDtos = pencilModels.Select(p => new PencilDto
        {
            Id = p.Id.ToString(),
            Name = p.Name, 
            Description = p.Description,
            Hardness = p.Hardness,
            Price = p.Price,
            StockQuantity = p.StockQuantity
        }).ToList();

        return pencilDtos;
    }
}
