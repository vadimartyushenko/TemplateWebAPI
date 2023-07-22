using System.Text.Json;

namespace TemplateMinimalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var summaries = new[]
            {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) => {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            });

            app.MapGet("/say-hello", async context =>
            {
                await context.Response.WriteAsync("Hello, everybody!");
            });

            app.MapGet("/env", async context =>
            {
                var hostEnvironment = context.RequestServices.GetRequiredService<IWebHostEnvironment>();
                var thisEnv = new
                {
                    ApplicationName = hostEnvironment.ApplicationName,
                    Environment = hostEnvironment.EnvironmentName
                };
                var jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
                await context.Response.WriteAsJsonAsync(thisEnv, jsonSerializerOptions);
            });

            app.Run();
        }
    }
}