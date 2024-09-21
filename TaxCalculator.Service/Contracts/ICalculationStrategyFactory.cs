using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Service.Contracts
{
    public interface ICalculationStrategyFactory
    {
        ICalculationStrategy CreateStrategy(string city);
    }
}
