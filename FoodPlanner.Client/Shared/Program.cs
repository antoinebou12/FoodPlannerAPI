public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        // Register your services here, e.g.:
        // builder.Services.AddScoped<RecipeService>();
        // builder.Services.AddScoped<FoodService>();
        // ...

        await builder.Build().RunAsync();
    }
}
