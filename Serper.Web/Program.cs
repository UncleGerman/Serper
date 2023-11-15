using Serper.Infrastructure.Injection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddDAL();
builder.Services.AddInjection();
builder.Services.AddBLL();
builder.Services.AddAPI();

builder.Services.AddControllers();

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});

var app = builder.Build();

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
});

#endregion

app.Run();