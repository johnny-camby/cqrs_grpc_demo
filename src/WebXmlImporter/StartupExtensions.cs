using Data.Repository;
using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using static XmlData.GrpcServices.CustomerData;
using System.Security.Cryptography.X509Certificates;
using Grpc.Net.Client;

namespace WebXmlImporter
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddBusinessLogicServices();
            builder.Services.AddPersistenceServices(builder.Configuration);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            var certificate = new X509Certificate2(
                configuration["Settings:Certificate:Name"],
                configuration["Settings:Certificate:Password"]);

            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(certificate);

            var httpClient = new HttpClient(handler);
            var options = new GrpcChannelOptions 
            {
                HttpClient = httpClient
            };

            var channel = GrpcChannel.ForAddress("https://localhost:7086", options);

            CustomerDataClient customerDataClient = new(channel);

            builder.Services.AddGrpcClient<CustomerDataClient>(c =>
             c.Address = new Uri("https://localhost:7086"));

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<XmlImporterDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }
}
