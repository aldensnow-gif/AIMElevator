using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
        c.IncludeXmlComments(xmlPath);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseSwagger();
app.MapControllers();
app.Lifetime.ApplicationStarted.Register(() =>
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    var urls = string.Join(", ", app.Urls);

    logger.LogInformation("Application running at: {Urls}", urls);

    if (app.Environment.IsDevelopment())
    {
        foreach (var url in app.Urls)
        {
            logger.LogInformation("Swagger UI available at: {SwaggerUrl}/swagger", url);
            logger.LogInformation("OpenAPI contract: {SwaggerJson}", $"{url}/swagger/v1/swagger.json");
        }
    }
});
app.Run();
