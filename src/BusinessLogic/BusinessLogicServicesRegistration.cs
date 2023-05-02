
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using XmlDataExtractManager.Interfaces;
using XmlDataExtractManager.Services;

namespace BusinessLogic
{
    public static class BusinessLogicServicesRegistration
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IBufferedFileUploadService, BufferedFileUploadService>();
            services.AddScoped<IXmlDataExtractorService, XmlDataExtractorService>();
            return services;
        }
    }
}
