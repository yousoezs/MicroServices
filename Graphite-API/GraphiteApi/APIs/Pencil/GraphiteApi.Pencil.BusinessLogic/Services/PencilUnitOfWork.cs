using GraphiteApi.Pencil.BusinessLogic.Interfaces;
using GraphiteApi.Pencil.DataAccess.Context;

namespace GraphiteApi.Pencil.BusinessLogic.Services;

public class PencilUnitOfWork : IPencilUnitOfWork
{
    private readonly PencilContext _context;

    public IPencilRepository Repository { get; set; }

    public PencilUnitOfWork(PencilContext context)
    {
        _context = context;
        Repository = new PencilRepository(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}