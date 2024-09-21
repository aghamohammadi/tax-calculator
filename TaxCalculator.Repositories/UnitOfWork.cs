using TaxCalculator.EntityBase.Context;
using TaxCalculator.EntityBase.Entity;


namespace TaxCalculator.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaxCalculatorDbContext _dbContext;

        public UnitOfWork(TaxCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IRepositories<City> _cityRepository;
        public IRepositories<City> CityRepository
        {
            get
            {
                return _cityRepository ??= new Repository<City>(_dbContext);
            }
        }



        private IRepositories<CityTaxRule> _cityTaxRuleRepository;
        public IRepositories<CityTaxRule> CityTaxRuleRepository
        {
            get
            {
                return _cityTaxRuleRepository ??= new Repository<CityTaxRule>(_dbContext);
            }
        }


        private IRepositories<Holiday> _holidayRepository;
        public IRepositories<Holiday> HolidayRepository
        {
            get
            {
                return _holidayRepository ??= new Repository<Holiday>(_dbContext);
            }
        }

        private IRepositories<MonthTaxExemption> _monthTaxExemptionRepository;
        public IRepositories<MonthTaxExemption> MonthTaxExemptionRepository
        {
            get
            {
                return _monthTaxExemptionRepository ??= new Repository<MonthTaxExemption>(_dbContext);
            }
        }

        private IRepositories<TaxAmount> _taxAmountRepository;
        public IRepositories<TaxAmount> TaxAmountRepository
        {
            get
            {
                return _taxAmountRepository ??= new Repository<TaxAmount>(_dbContext);
            }
        }

        
        private IRepositories<Vehicle> _vehicleRepository;
        public IRepositories<Vehicle> VehicleRepository
        {
            get
            {
                return _vehicleRepository ??= new Repository<Vehicle>(_dbContext);
            }
        }

        private IRepositories<VehicleExemption> _vehicleExemptionRepository;
        public IRepositories<VehicleExemption> VehicleExemptionRepository
        {
            get
            {
                return _vehicleExemptionRepository ??= new Repository<VehicleExemption>(_dbContext);
            }
        }

        private IRepositories<WeekendDay> _weekendDayRepository;
        public IRepositories<WeekendDay> WeekendDayRepository
        {
            get
            {
                return _weekendDayRepository ??= new Repository<WeekendDay>(_dbContext);
            }
        }




        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


        public void Dispose()
        {
            _dbContext.Dispose();

        }
    }
}
