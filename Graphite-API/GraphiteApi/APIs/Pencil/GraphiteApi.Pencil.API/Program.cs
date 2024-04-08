using FastEndpoints;
using FastEndpoints.Swagger;
using GraphiteApi.Pencil.BusinessLogic.Interfaces;
using GraphiteApi.Pencil.BusinessLogic.Services;
using GraphiteApi.Pencil.DataAccess.Context;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var hostname = Environment.GetEnvironmentVariable("DB_HOST_PENCIL");
var databaseName = Environment.GetEnvironmentVariable("DB_DATABASE_PENCIL");
var connectionString = $"mongodb://{hostname}:27017";

var client = new MongoClient(connectionString);

builder.Services.AddMongoDB<PencilContext>(client, databaseName);

builder.Services.AddScoped<IPencilRepository, PencilRepository>();
builder.Services.AddScoped<IPencilUnitOfWork, PencilUnitOfWork>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDocument();

var app = builder.Build();

app.UseRouting();
app.UseDefaultExceptionHandler();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
