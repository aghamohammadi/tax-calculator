using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.Service.Contracts;

namespace TaxCalculator.Service
{
    public class CalculationStrategyFactory : ICalculationStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CalculationStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public ICalculationStrategy CreateStrategy(string strategyType)
        {
            switch (strategyType.ToLower())
            {
                case "strategy1":
                    return ActivatorUtilities.CreateInstance<DefaultCalculationStrategy>(_serviceProvider);
                    //return new DefaultCalculationStrategy();
                default:
                    throw new ArgumentException("Unknown strategy type");
            }
        }
    }
}
