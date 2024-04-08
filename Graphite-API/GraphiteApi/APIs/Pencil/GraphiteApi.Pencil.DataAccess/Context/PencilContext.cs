using GraphiteApi.Pencil.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace GraphiteApi.Pencil.DataAccess.Context;

public class PencilContext : DbContext
{
    public DbSet<PencilModel> Pencils { get; init; }

    public static PencilContext Create(IMongoDatabase database) => new(
        new DbContextOptionsBuilder<PencilContext>()
            .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
            .Options
        );

    public PencilContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PencilModel>().ToCollection("pencils");
    }
}