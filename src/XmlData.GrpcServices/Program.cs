
using Data.Repository;
using Microsoft.AspNetCore.Authentication.Certificate;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using XmlData.GrpcServices.Services;
using XmlDataExtractManager.Interfaces;
using XmlDataExtractManager.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options => 
{
    options.ConfigureHttpsDefaults(httpCtx => httpCtx.ClientCertificateMode = ClientCertificateMode.AllowCertificate);
});

RegisterService(builder);
builder.Services.AddScoped<IXmlDataExtractorService, XmlDataExtractorService>();


builder.Services.AddGrpc();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
app.MapGrpcService<CustomerService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
  

static void RegisterService(WebApplicationBuilder builder)
{
    builder.Services.AddAuthentication()
        .AddCertificate(opt =>
        {
            opt.AllowedCertificateTypes = CertificateTypes.All;
            opt.RevocationMode = X509RevocationMode.NoCheck; // Self-Signed

            opt.Events = new CertificateAuthenticationEvents 
            {
                OnCertificateValidated = ctx =>
                {
                    if(ctx.ClientCertificate.Issuer == "CN=JCambyRootCert")
                    {
                        ctx.Success();
                    }
                    else
                    {
                        ctx.Fail("Invalid Certificate Issuer");
                    }
                    return Task.CompletedTask;
                }
            };

        });

    builder.Services.AddAuthorization();

    builder.Services.AddGrpc(cfg => cfg.EnableDetailedErrors = true);
}