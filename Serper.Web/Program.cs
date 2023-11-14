using Serper.Infrastructure.Injection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddDAL();
builder.Services.AddInjection();
builder.Services.AddBLL();
builder.Services.AddAPI();

var app = builder.Build();

app.Run();