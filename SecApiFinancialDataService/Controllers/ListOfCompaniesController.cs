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
        private readonly IFinancialDataService _financialDataService;

        public ListOfCompaniesController(IFinancialDataService financialPositionService)
        {
            _financialDataService = financialPositionService;
        }

        [HttpGet]
        public async Task<ActionResult> GetListOfCompaniesAsync()
        {
            IList<CompanyDynamoItem> dynamoItems = await _financialDataService.GetListOfCompaniesAsync();

            return Ok(dynamoItems);
        }

        [HttpGet]
        [Route("{cikNumber}")]
        public async Task<ActionResult> GetCompanyInfoAsync(string cikNumber)
        {
            CompanyDynamoItem dynamoItem = await _financialDataService.GetCompanyInfoAsync(cikNumber);

            return Ok(dynamoItem);
        }
    }
}
