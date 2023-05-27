using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql;
using System;
using Prometheus;
using App.Metrics;
using App.Metrics.AspNetCore;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Exporter;
using OpenTelemetry.Instrumentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RecipeContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddControllers();
builder.Services.AddScoped<RecipeSeeder>();

builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddMetrics();

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


using var server = new MetricServer(port: 1234);
server.Start();

// Add Redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost"; // Replace with your Redis connection string
    options.InstanceName = "RecipeMicroservice_";
});

builder.Services.AddDistributedMemoryCache();

// Configure Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Recipe Microservice API",
        Description = "A Microservice for Managing Recipes",
        TermsOfService = new Uri("https://github.com/antoinebou12/foodplannerapi/blob/main/LICENSE"),
        Contact = new OpenApiContact
        {
            Name = "Antoine Boucher",
            Email = "antoine.boucher012@gmail.com",
            Url = new Uri("https://antoineboucher.info"),
        },
        License = new OpenApiLicense
        {
            Name = "Use under MIT",
            Url = new Uri("https://github.com/antoinebou12/foodplannerapi/blob/main/LICENSE")
        }
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

app.Use(async (context, next) =>
{
    using (var scope = app.Services.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetRequiredService<RecipeSeeder>();
        await seeder.SeedData("Data/Recipes.csv");
    }

    await next.Invoke();
});

// app.UseMetrics();

app.Run();

Console.WriteLine("Open http://localhost:1234/metrics in a web browser.");
Console.WriteLine("Press enter to exit.");
Console.ReadLine();