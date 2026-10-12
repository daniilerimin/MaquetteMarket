var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddApplicationServices();

var withApiVersioning = builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
});

builder.AddDefaultOpenApi(withApiVersioning);

var app = builder.Build();

app.MapDefaultEndpoints();

var webHooks = app.NewVersionedApi("Web Hooks");

webHooks.MapWebHooksApiV1()
        .RequireAuthorization();

app.UseDefaultOpenApi();
app.Run();

