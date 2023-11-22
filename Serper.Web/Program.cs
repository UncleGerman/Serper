using Serper.Infrastructure.Injection;
using Microsoft.AspNetCore.SpaServices.AngularCli;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext(builder.Configuration);
        builder.Services.AddDAL();
        builder.Services.AddBLL();
        builder.Services.AddAPI();

        builder.Services.AddCors(option =>
        {
            option.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        builder.Services.AddControllers();

        builder.Services.AddSpaStaticFiles(configuration =>
        {
            configuration.RootPath = "ClientApp/dist";
        });

        var app = builder.Build();

        var environment = app.Environment;

        app.UseRouting();
        app.UseCors();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

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
    }
}