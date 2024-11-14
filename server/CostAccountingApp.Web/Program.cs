using System.Reflection;
using CostAccountingApp.ApplicationCore;
using CostAccountingApp.ApplicationCore.Interfaces;
using CostAccountingApp.ApplicationCore.Services;
using CostAccountingApp.Infrastructure.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.SetIsOriginAllowed(_ => true).AllowCredentials().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg=> cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddApplicationCore();
builder.Services.AddTransient<ICostAccountingService, CostAccountingService>();
builder.Services.AddTransient<IRepository, PurchaseLotRepository>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CostAccountingApp", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CostAccountingApp v1"));

app.UseCors("AllowAllOrigins");

app.UseRouting();
app.MapControllers();
app.Run();