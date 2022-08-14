using Microsoft.AspNetCore.Mvc;
using SecApiFinancialDataService.Model;
using SecApiFinancialDataService.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecApiFinancialDataService.Controllers
{
    [Route("list-of-companies")]
    [ApiController]
    public class ListOfCompaniesController : ControllerBase
    {
        private readonly IFinancialDataService _financialPositionService;

        public ListOfCompaniesController(IFinancialDataService financialPositionService)
        {
            _financialPositionService = financialPositionService;
        }

        [HttpGet]
        public async Task<ActionResult> GetListOfCompaniesAsync()
        {
            IList<CompanyDynamoItem> dynamoItems = await _financialPositionService.GetListOfCompaniesAsync();

            return Ok(dynamoItems);
        }
    }
}
