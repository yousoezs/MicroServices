using GraphiteApi.Domain.Commons.Services;
using GraphiteApi.Pencil.BusinessLogic.Interfaces;
using GraphiteApi.Pencil.DataAccess.Context;
using GraphiteApi.Pencil.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace GraphiteApi.Pencil.BusinessLogic.Services;

public class PencilRepository : IPencilRepository
{
    private readonly PencilContext _context;


    public PencilRepository(PencilContext context)
    {
        _context = context;
    }


    public async Task<ServiceResponse<PencilModel>> GetByIdAsync(ObjectId id)
    {
        var pencil = await _context.Pencils.FindAsync(id);

        if (pencil is null)
        {
            return new ServiceResponse<PencilModel>(
                false,
                null,
                $"Can't find any Pencils with id: '{id}'");
        }

        return new ServiceResponse<PencilModel>(true, pencil, "");
    }

    public async Task<ServiceResponse<IEnumerable<PencilModel>>> GetAllAsync()
    {
        var pencils = await _context.Pencils.AsNoTracking().ToListAsync();

        if (!pencils.Any())
        {
            return new ServiceResponse<IEnumerable<PencilModel>>(
                false,
                null,
                "No Pencils in database");
        }

        return new ServiceResponse<IEnumerable<PencilModel>>(true, pencils, "");
    }

    public async Task<ServiceResponse<PencilModel>> AddAsync(PencilModel entity)
    {
        var existingEntityWithId = await _context.Pencils.AnyAsync(p => p.Id == entity.Id);

        if (existingEntityWithId)
        {
            return new ServiceResponse<PencilModel>(
                false,
                null,
                $"Pencil with Id: {entity.Id} already exists.");
        }

        var entityEntry = _context.Pencils.Add(entity);

        if (entityEntry.State != EntityState.Added)
        {
            return new ServiceResponse<PencilModel>(
                false,
                null,
                $"Can't add Pencil '{entityEntry.Entity.Name}' to database");
        }

        return new ServiceResponse<PencilModel>(
            true,
            entityEntry.Entity,
            $"Pencil added to database 'Name: {entityEntry.Entity.Name}'");
    }

    public async Task<ServiceResponse<PencilModel>> UpdateAsync(PencilModel entity)
    {
        var pencilToUpdate = await _context.Pencils.FindAsync(entity.Id);

        if (pencilToUpdate is null)
        {
            return new ServiceResponse<PencilModel>(false, null, $"Can't find Pencil with Id: {entity.Id}");
        }

        pencilToUpdate.Name = entity.Name;
        pencilToUpdate.Description = entity.Description;
        pencilToUpdate.CreatedDate = entity.CreatedDate;
        pencilToUpdate.UpdatedDate = DateTime.Now;
        pencilToUpdate.Hardness = entity.Hardness;
        pencilToUpdate.Price = entity.Price;
        pencilToUpdate.StockQuantity = entity.StockQuantity;

        _context.Pencils.Update(pencilToUpdate);

        return new ServiceResponse<PencilModel>(true, pencilToUpdate, $"Updated Pencil Id: {pencilToUpdate.Id}");
    }

    public async Task<ServiceResponse<PencilModel>> DeleteAsync(ObjectId id)
    {
        var pencilToDelete = await _context.Pencils.FindAsync(id);

        if (pencilToDelete is null)
        {
            return new ServiceResponse<PencilModel>(false, null, $"Pencil with Id: {id} couldn't be found");
        }

        var entityState = _context.Pencils.Remove(pencilToDelete);

        if (entityState.State != EntityState.Deleted)
        {
            return new ServiceResponse<PencilModel>(false, null, $"Couldn't delete Pencil with Id: {id}");
        }

        return new ServiceResponse<PencilModel>(true, null, $"Pencil with Id: {id} has been deleted");
    }
}