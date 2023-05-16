using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql;
using Prometheus;
using App.Metrics;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Confluent.Kafka;
using Recipe.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RecipeContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddControllers();
builder.Services.AddScoped<Recipe.Data.RecipeSeeder>();

builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddMetrics();

// Add Kafka Producer
var producerConfig = new ProducerConfig();
builder.Configuration.Bind("Producer", producerConfig);
builder.Services.AddSingleton(producerConfig);

// Add Telemetry
Sdk.CreateTracerProviderBuilder()
    .AddSource("RecipeMicroservice")
    .AddAspNetCoreInstrumentation()
    .AddHttpClientInstrumentation()
    .AddJaegerExporter(o =>
    {
        o.AgentHost = "localhost";
        o.AgentPort = 6831;
    })
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("RecipeMicroservice"))
    .Build();

// Add Redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";
    options.InstanceName = "RecipeMicroservice_";
});

builder.Services.AddDistributedMemoryCache();

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Recipe Microservice API", 
        Version = "v1" 
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recipe Microservice v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

Console.WriteLine("Open http://localhost:1234/metrics in a web browser.");
Console.WriteLine("Press enter to exit.");
Console.ReadLine();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<Recipe.Data.RecipeSeeder>();
    seeder.SeedData("Data/fixtures/Recipes.csv").Wait();
    seeder.SeedData("Data/fixtures/Ingredients.csv").Wait();
    seeder.SeedData("Data/fixtures/Instructions.csv").Wait();
    seeder.SeedData("Data/fixtures/NutritionInfo.csv").Wait();
    seeder.SeedData("Data/fixtures/Tags.csv").Wait();
}

app.Run();
