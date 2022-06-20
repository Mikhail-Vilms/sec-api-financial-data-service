using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecApiFinancialDataService.Model;
using SecApiFinancialDataService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecApiFinancialDataService.Controllers
{
    [Route("api/financial-data")]
    [ApiController]
    public class FinancialDataController : ControllerBase
    {
        private readonly IFinancialPositionService _financialPositionService;

        public FinancialDataController(IFinancialPositionService financialPositionService)
        {
            _financialPositionService = financialPositionService;
        }

        [HttpGet]
        [Route("{cikNumber}/{statement}/{position}")]
        // https://localhost:44306/api/financial-data/CIK0000050863/BalanceSheet/Assets
        public async Task<ActionResult> GetFinancialPositionAsync(
            string cikNumber,
            string statement,
            string position)
        {
            FinancialPositionDynamoItem dynamoItem = await _financialPositionService
                .GetFinancialPosition(cikNumber, statement, position);

            return Ok(dynamoItem);
        }
    }
}
