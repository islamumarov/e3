using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PlatformService;
using PlatformService.Data;
using PlatformService.SyncDataServives.Http;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
if (builder.Environment.IsProduction())
{
    Console.WriteLine("----> Using SQL Server Db");
    builder.Services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConn")));
}
else
{
    Console.WriteLine("------------> Using in-memory database");
    builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("InMem"));
}
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "PlatformService", Version = "v1" });
});
Console.WriteLine($"-------> CommandService Endpoint {builder.Configuration["CommandService"]}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    Console.WriteLine("Development Evn");
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlatformService v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
PrepDb.PrepPopulation(app, !builder.Environment.IsProduction());
app.Run();
