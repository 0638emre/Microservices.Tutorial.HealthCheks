using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks()
    .AddRedis(
        redisConnectionString:"localhost:6379",
        name: "Redis Check",
        failureStatus: HealthStatus.Degraded | HealthStatus.Unhealthy,
        tags:new string[] {"redis"}
        )
    .AddMongoDb(
        "mongodb://localhost:27017",
        name: "MongoDB Check",
        failureStatus: HealthStatus.Degraded | HealthStatus.Unhealthy,
        tags: new string[] { "mongodb" }
        )
    .AddSqlServer(
        "Server=91.241.49.224, 1433;Database=TaskyDB;User ID=sa;Password=010203Ankara;TrustServerCertificate=True;",
        name: "sqlserver check",
        failureStatus: HealthStatus.Degraded | HealthStatus.Unhealthy,
        tags: new string[] { "sqlserver" , "sql", "db"}
        );

var app = builder.Build();

app.UseHealthChecks("/health", new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();