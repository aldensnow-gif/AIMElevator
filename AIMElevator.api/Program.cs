using AIMElevator.api.CallToFloor;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .ConfigureApplicationPartManager(apm =>
    {
        apm.ApplicationParts.Clear(); // Remove auto-generated controllers (e.g. OpenAPI/NSwag) to avoid endpoint conflicts; we then add only this assembly's controllers. Consider generating server interfaces from the OpenAPI contract (NSwag) to enforce the API contract.
        apm.ApplicationParts.Add(new AssemblyPart(typeof(Program).Assembly));
    });

builder.Services.AddScoped<ICallToFloorHandler, CallToFloorHandler>();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

