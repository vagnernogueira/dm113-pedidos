using dm113_pedidos.Service;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPedidoService, PedidoService>();

var app = builder.Build();

app.MapGet("/", () =>
{
    return Results.Ok("OK!");
});

app.UseSoapEndpoint<IPedidoService>("/Service.asmx", new SoapEncoderOptions());

app.Run();