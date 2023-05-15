using WebXmlImporter;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .ConfigureServices(builder.Configuration)
    .ConfigurePipeline();
await app.ResetDatabaseAsync();

app.Run();
