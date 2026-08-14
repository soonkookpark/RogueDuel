using Microsoft.EntityFrameworkCore;
using RogueDuel.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<RogueDuelDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("RogueDuelDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// v0.1 EF Core 연결 확인용 헬스체크 엔드포인트
app.MapGet("/health/db", async (RogueDuelDbContext db) =>
{
    var canConnect = await db.Database.CanConnectAsync();
    return canConnect
        ? Results.Ok(new { status = "ok", database = "connected" })
        : Results.StatusCode(StatusCodes.Status503ServiceUnavailable);
});

app.Run();
