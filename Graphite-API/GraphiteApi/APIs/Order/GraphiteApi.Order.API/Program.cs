using FastEndpoints;
using FastEndpoints.Swagger;
using GraphiteApi.Order.API.Services.Interfaces;
using GraphiteApi.Order.API.Services.User;
using GraphiteApi.Order.BusinessLogic.Interfaces;
using GraphiteApi.Order.BusinessLogic.Managers;
using GraphiteApi.Order.BusinessLogic.Repositories;
using GraphiteApi.Order.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var host = Environment.GetEnvironmentVariable("DB_HOST_ORDER");
var database = Environment.GetEnvironmentVariable("DB_DATABASE_ORDER");
var username = Environment.GetEnvironmentVariable("DB_USER_ORDER");
var password = Environment.GetEnvironmentVariable("DB_MSSQL_SA_PASSWORD_ORDER");
var connectionString = $"Data Source={host};Initial Catalog={database};User ID={username};Password={password};Trusted_connection=false;TrustServerCertificate=True;";

builder.Services.AddHttpClient("graphiteapi.user.api", c => c.BaseAddress = new System.Uri("http://graphiteapi.user.api:8080"));
builder.Services.AddHttpClient("graphiteapi.pencil.api", c => c.BaseAddress = new System.Uri("http://graphiteapi.pencil.api:8080"));

builder.Services.AddSqlServer<OrderContext>(connectionString);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGetUserHttpClient, GetUserHttpClient>();

builder.Services
    .AddFastEndpoints()
    .AddSwaggerDocument();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseRouting();

app
    .UseFastEndpoints()
    .UseSwaggerGen();


OrderRepositoryManager.SubscribeEvents();

app.Run();