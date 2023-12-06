var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services
            .AddHealthChecksVueUI()
            .AddInMemoryStorage();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
        );
});


var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
app.UseRouting();

app
            .UseRouting()
            .UseEndpoints(config => config.MapHealthChecksUI());


app.Run();

//using Microsoft.AspNetCore;

//namespace HealthChecks.UI.Sample;

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        CreateWebHostBuilder(args).Build().Run();
//    }

//    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
//        WebHost.CreateDefaultBuilder(args)
//            .UseStartup<Startup>();
//}
