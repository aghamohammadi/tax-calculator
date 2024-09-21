using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Threading.Tasks;
using TaxCalculator.Api.Controllers;
using TaxCalculator.DtoModels;
using TaxCalculator.Service;
using TaxCalculator.Service.Contracts;
using Xunit;
using TaxCalculator.Repositories;
using TaxCalculator.EntityBase.Context;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.AutoMapper;

namespace TaxCalculator.Test
{
    public class DefaultCalculationStrategyRealTests
    {
        private readonly IServiceProvider _serviceProvider;

        public DefaultCalculationStrategyRealTests()
        {
            var services = new ServiceCollection();

            // ثبت واقعی سرویس‌ها
            services.AddDbContext<TaxCalculatorDbContext>(options =>
    options.UseSqlServer("data source=.;initial catalog=TaxCalculator;persist security info=True;Integrated Security=SSPI;TrustServerCertificate=True;"));
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IExemptDateService, ExemptDateService>();
            services.AddTransient<ITaxAmountService, TaxAmountService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(CityProfile).Assembly);

            //services.AddTransient<ICalculationStrategy, DefaultCalculationStrategy>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task CalculateTaxAsync_ShouldReturnCorrectTaxAmount_WhenValidInputs()
        {
            



            var testCity = "Gothenburg";
            var testYear = 2013;
            var testLicensePlate = "PRV-001";
            var testDates = new DateTime[]
            {
                new DateTime(2013, 01, 14, 21, 00, 00),
                new DateTime(2013, 01, 15, 21, 00, 00),
                new DateTime(2013, 02, 07, 06, 23, 27),
                new DateTime(2013, 02, 07, 15, 27, 00),
                new DateTime(2013, 02, 08, 06, 27, 00),
                new DateTime(2013, 02, 08, 06, 20, 27),
                new DateTime(2013, 02, 08, 14, 35, 00),
                new DateTime(2013, 02, 08, 15, 29, 00),
                new DateTime(2013, 02, 08, 15, 47, 00),
                new DateTime(2013, 02, 08, 16, 01, 00),
                new DateTime(2013, 02, 08, 16, 48, 00),
                new DateTime(2013, 02, 08, 17, 49, 00),
                new DateTime(2013, 02, 08, 18, 29, 00),
                new DateTime(2013, 02, 08, 18, 35, 00),
                new DateTime(2013, 03, 26, 14, 25, 00),
                new DateTime(2013, 03, 28, 14, 07, 27)
            };

           

            var form = new VehicleDataForm
            {
                City = testCity,
                Year = testYear,
                VehicleLicensePlate = testLicensePlate,
                Dates = testDates
            };
            var factory = new CalculationStrategyFactory(_serviceProvider);
            var strategy1 = factory.CreateStrategy("Strategy1");


            // Act
            var result = await strategy1.CalculateTaxAsync(form.City, form.Year, form.VehicleLicensePlate, form.Dates);
            var expectedTaxAmount = 97m;

            // Assert
            Assert.Equal(expectedTaxAmount, result); // Expected result based on the mock setup
        }
    }
}
