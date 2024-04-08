using GraphiteApi.User.DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace GraphiteApi.User.DataAccess.Contexts;

public sealed class UserContext : DbContext
{
	public DbSet<UserModel> User { get; set; } = null!;

	public UserContext(DbContextOptions<UserContext> options) : base(options)
	{
		try
		{
			if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator)
			{
				if (!databaseCreator.CanConnect()) databaseCreator.Create();
				if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}