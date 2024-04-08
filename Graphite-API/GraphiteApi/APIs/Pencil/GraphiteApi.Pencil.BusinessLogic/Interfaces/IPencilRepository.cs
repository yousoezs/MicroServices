using GraphiteApi.Domain.Commons.Interfaces;
using GraphiteApi.Pencil.DataAccess.Models;
using MongoDB.Bson;

namespace GraphiteApi.Pencil.BusinessLogic.Interfaces;

public interface IPencilRepository : IGenericRepository<PencilModel, ObjectId>
{
    
}