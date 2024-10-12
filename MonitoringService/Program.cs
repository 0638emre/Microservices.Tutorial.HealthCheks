var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecksUI(setting =>
{
    setting.AddHealthCheckEndpoint("servis 1", "http://localhost:5019/health");
    setting.AddHealthCheckEndpoint("servis 2", "http://localhost:5056/health");
}).AddSqlServerStorage("Server=localhost, 1433; Database=HealthCheckUIDB;User ID=sa;Password=reallyStrongPwd123;TrustServerCertificate=True");
    
    
    // ("Server=localhost, 1433; Database=HealthCheckUIDB;User ID=sa;Password=reallyStrongPwd123;TrustServerCertificate=True");


var app = builder.Build();

app.UseHealthChecksUI(opt => opt.UIPath = "/healthUI");

app.Run();