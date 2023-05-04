public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Add the DbContext and configure it to use MongoDB
        services.AddDbContext<RecipeFoodPlannerContext>(options =>
            options.UseMongoDB(Configuration.GetConnectionString("MongoDB")));

        // Register your repositories here, e.g.:
        // services.AddScoped<RecipeRepository>();
        // services.AddScoped<FoodRepository>();
        // ...
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
