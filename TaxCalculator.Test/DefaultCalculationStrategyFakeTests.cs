using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using TaxCalculator.Service.Contracts;
using TaxCalculator.EntityBase.Entity;
using TaxCalculator.Service;
using TaxCalculator.DtoModels;

namespace TaxCalculator.Tests
{
    public class DefaultCalculationStrategyFakeTests
    {
        [Fact]
        public async Task CalculateTaxAsync_ShouldReturnCorrectTaxAmount()
        {
            // Arrange
            var cityServiceMock = new Mock<ICityService>();
            var vehicleServiceMock = new Mock<IVehicleService>();
            var exemptDateServiceMock = new Mock<IExemptDateService>();
            var taxAmountServiceMock = new Mock<ITaxAmountService>();

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

            var city = new CityDto { Id = 1, Name = testCity };
            var taxRule = new CityTaxRuleDto { Id = 1, CityId = 1, Year = testYear, HasSingleChargeRule = true, SingleChargeWindowInMinutes = 60, MaxAmountPerDay = 60 };
            var vehicle = new VehicleDto { Id = 1, LicensePlate = testLicensePlate, VehicleType = "Car" };

            cityServiceMock.Setup(c => c.GetCityAsync(testCity)).ReturnsAsync(city);
            cityServiceMock.Setup(c => c.GetRulesAsync(city.Id, testYear)).ReturnsAsync(taxRule);
            vehicleServiceMock.Setup(v => v.GetByLicensePlateAsync(testLicensePlate)).ReturnsAsync(vehicle);
            vehicleServiceMock.Setup(v => v.HasVehicleExemption(city.Id, vehicle.VehicleType)).ReturnsAsync(false);

            // Mock exempt date service
            exemptDateServiceMock.Setup(e => e.CheckMonthExemption(It.IsAny<DateTime>(), city.Id)).ReturnsAsync(false);
            exemptDateServiceMock.Setup(e => e.CheckWeekendExemption(It.IsAny<DateTime>(), city.Id)).ReturnsAsync(false);
            exemptDateServiceMock.Setup(e => e.CheckHolidayExemption(It.IsAny<DateTime>(), city.Id)).ReturnsAsync(false);
            exemptDateServiceMock.Setup(e => e.CheckBeforeHolidayExemption(It.IsAny<DateTime>(), city.Id)).ReturnsAsync(false);

            // Mock tax amount service for different times
            taxAmountServiceMock.Setup(t => t.GetTaxAmount(It.Is<TimeOnly>(time => time >= new TimeOnly(6, 0) && time < new TimeOnly(6, 30)), city.Id, testYear)).ReturnsAsync(8);
            taxAmountServiceMock.Setup(t => t.GetTaxAmount(It.Is<TimeOnly>(time => time >= new TimeOnly(6, 30) && time < new TimeOnly(7, 0)), city.Id, testYear)).ReturnsAsync(13);
            taxAmountServiceMock.Setup(t => t.GetTaxAmount(It.Is<TimeOnly>(time => time >= new TimeOnly(7, 0) && time < new TimeOnly(8, 0)), city.Id, testYear)).ReturnsAsync(18);
            taxAmountServiceMock.Setup(t => t.GetTaxAmount(It.Is<TimeOnly>(time => time >= new TimeOnly(8, 0) && time < new TimeOnly(8, 30)), city.Id, testYear)).ReturnsAsync(13);
            taxAmountServiceMock.Setup(t => t.GetTaxAmount(It.Is<TimeOnly>(time => time >= new TimeOnly(8, 30) && time < new TimeOnly(15, 0)), city.Id, testYear)).ReturnsAsync(8);
            taxAmountServiceMock.Setup(t => t.GetTaxAmount(It.Is<TimeOnly>(time => time >= new TimeOnly(15, 0) && time < new TimeOnly(15, 30)), city.Id, testYear)).ReturnsAsync(13);
            taxAmountServiceMock.Setup(t => t.GetTaxAmount(It.Is<TimeOnly>(time => time >= new TimeOnly(15, 30) && time < new TimeOnly(17, 0)), city.Id, testYear)).ReturnsAsync(18);
            taxAmountServiceMock.Setup(t => t.GetTaxAmount(It.Is<TimeOnly>(time => time >= new TimeOnly(17, 0) && time < new TimeOnly(18, 0)), city.Id, testYear)).ReturnsAsync(13);
            taxAmountServiceMock.Setup(t => t.GetTaxAmount(It.Is<TimeOnly>(time => time >= new TimeOnly(18, 0) && time < new TimeOnly(18, 30)), city.Id, testYear)).ReturnsAsync(8);
            taxAmountServiceMock.Setup(t => t.GetTaxAmount(It.Is<TimeOnly>(time => time >= new TimeOnly(18, 30) || time < new TimeOnly(6, 0)), city.Id, testYear)).ReturnsAsync(0);

            var strategy = new DefaultCalculationStrategy(cityServiceMock.Object, vehicleServiceMock.Object, exemptDateServiceMock.Object, taxAmountServiceMock.Object);

            // Act
            var result = await strategy.CalculateTaxAsync(testCity, testYear, testLicensePlate, testDates);

            // Assert
            Assert.Equal(97, result); 
        }
    }
}
