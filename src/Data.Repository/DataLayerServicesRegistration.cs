
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using Data.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Repository
{
    public static class DataLayerServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<XmlImporterDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CustomersOrdersDbGrpcConn"),
                m => m.MigrationsAssembly("Data.Repository"))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped<IXmlImporterRepository<CustomerEntity>, CustomerRepository>();
            services.AddScoped<IXmlImporterRepository<FullAddressEntity>, FullAddressRepository>();
            services.AddScoped<IXmlImporterRepository<OrderEntity>, OrderRepository>();
            services.AddScoped<IXmlImporterRepository<ShipInfoEntity>, ShipInfoRepository>();

            return services;
        }
    }
}
