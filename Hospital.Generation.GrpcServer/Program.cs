using Hospital.Generation.GrpcServer.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Добавляем gRPC
builder.Services.AddGrpc();

// Настройка Kestrel для поддержки HTTP/2 на локальном порту 5002
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5002, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2; // HTTP/2 обязательно для gRPC
    });
});

var app = builder.Build();

// Привязываем gRPC сервис
app.MapGrpcService<GenerationServiceImpl>();

// Простейший GET для проверки
app.MapGet("/", () => "gRPC server running...");

app.Run();
