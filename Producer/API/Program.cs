using Consumer;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Net;

internal class Program
{
    public static void Main(string[] args)
    {
        ////var builder = WebApplication.CreateBuilder(args);

     

        //////builder.Services.AddControllers();
        ////// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        ////builder.Services.AddTransient<Worker>();
        ////builder.Services.AddEndpointsApiExplorer();
        ////builder.Services.AddSwaggerGen();
        ////builder.Services.AddDbContext<MessageDbContext>(options =>
        ////{
        ////    //options.UseNpgsql($"Server=localhost;Database=testappdb;Port=5432;User Id=root;Password=mysecretpassword");
        ////    options.UseNpgsql($"Server={ip};Username=root;Database=postgres;Password=mysecretpassword");
        ////});
        ////builder.Services.AddScoped<MessageValueObjectRepository>();

        //var collection = new Microsoft.Extensions.DependencyInjection.ServiceCollection()
        //    .AddTransient<Worker>()
        //    .AddDbContext<MessageDbContext>(options =>
        //    {
        //        //options.UseNpgsql($"Server=localhost;Database=testappdb;Port=5432;User Id=root;Password=mysecretpassword");
        //        options.UseNpgsql($"Server={ip};Username=root;Database=postgres;Password=mysecretpassword");
        //    })
        //    .AddScoped<MessageValueObjectRepository>();

        //var worker  = collection.getserive<Worker>();
        //worker.();
        ////var app = builder.Build();

        ////app.Run();
        var ip = Dns.GetHostAddresses("db")[0].ToString();
        CreateHostBuilder(args, ip).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args, string   ip ) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
                services.AddDbContext<MessageDbContext>(options =>
                 {
                     //options.UseNpgsql($"Server=localhost;Database=testappdb;Port=5432;User Id=root;Password=mysecretpassword");
                     options.UseNpgsql($"Server={ip};Username=root;Database=postgres;Password=example");
                 });
          services  .AddScoped<MessageValueObjectRepository>();
            });
}