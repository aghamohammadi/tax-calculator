using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.DtoModels;
using TaxCalculator.Service.Contracts;

namespace TaxCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ICalculationStrategyFactory _strategyFactory;

        public TaxController(ICalculationStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        [HttpPost]
        [Route("cal-tax")]
        public async Task<object> CalTaxAsync([FromBody] VehicleDataForm form)
        {
            try
            {
                var strategy1 = _strategyFactory.CreateStrategy("Strategy1");
                var result = await strategy1.CalculateTaxAsync(form.City, form.Year, form.VehicleLicensePlate, form.Dates);

                return Ok(new
                {
                    status=200,
                    data= result
                });

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

    }
}
