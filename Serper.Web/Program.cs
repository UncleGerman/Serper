using Serper.Infrastructure.Injection;
using Microsoft.AspNetCore.SpaServices.AngularCli;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddDAL();
builder.Services.AddInjection();
builder.Services.AddBLL();
builder.Services.AddAPI();

var app = builder.Build();

builder.Services.AddControllers();

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});

var app = builder.Build();

var environment = app.Environment;

#region Routing

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

#endregion

#region Angular

app.UseStaticFiles();

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    if (environment.IsDevelopment())
    {
        spa.UseAngularCliServer(npmScript: "start");
    }
});

#endregion

app.Run();