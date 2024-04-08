using FastEndpoints;
using FastEndpoints.Swagger;
using GraphiteApi.User.BusinessLogic.Interfaces;
using GraphiteApi.User.BusinessLogic.Services;
using GraphiteApi.User.DataAccess.Contexts;

var builder = WebApplication.CreateBuilder(args);

var host = Environment.GetEnvironmentVariable("DB_HOST_USER");
var database = Environment.GetEnvironmentVariable("DB_DATABASE_USER");
var username = Environment.GetEnvironmentVariable("DB_USER_USER");
var password = Environment.GetEnvironmentVariable("DB_MSSQL_SA_PASSWORD_USER");
var connectionString =
	$"Data Source={host};Initial Catalog={database};User ID={username};Password={password};Trusted_connection=False;TrustServerCertificate=True;";

builder.Services.AddSqlServer<UserContext>(connectionString);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services
	.AddFastEndpoints()
	.AddSwaggerDocument();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseRouting();

app
	.UseFastEndpoints()
	.UseSwaggerGen();


app.Run();
