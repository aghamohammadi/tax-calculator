using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TaxCalculator.AutoMapper;
using TaxCalculator.EntityBase.Context;
using TaxCalculator.Repositories;
using TaxCalculator.Service;
using TaxCalculator.Service.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(CityProfile).Assembly); 


builder.Services.AddDbContext<TaxCalculatorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IExemptDateService, ExemptDateService>();
builder.Services.AddScoped<ITaxAmountService, TaxAmountService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICalculationStrategyFactory, CalculationStrategyFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
