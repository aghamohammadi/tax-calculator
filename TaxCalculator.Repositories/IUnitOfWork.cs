using TaxCalculator.EntityBase.Entity;

namespace TaxCalculator.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositories<City> CityRepository { get; }
        IRepositories<CityTaxRule> CityTaxRuleRepository { get; }
        IRepositories<Holiday> HolidayRepository { get; }
        IRepositories<MonthTaxExemption> MonthTaxExemptionRepository { get; }
        IRepositories<TaxAmount> TaxAmountRepository { get; }
        IRepositories<Vehicle> VehicleRepository { get; }
        IRepositories<VehicleExemption> VehicleExemptionRepository { get; }
        IRepositories<WeekendDay> WeekendDayRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
