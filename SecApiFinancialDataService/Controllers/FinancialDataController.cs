using Microsoft.AspNetCore.Mvc;
using SecApiFinancialDataService.Model;
using SecApiFinancialDataService.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecApiFinancialDataService.Controllers
{
    [Route("financial-data")]
    [ApiController]
    public class FinancialDataController : ControllerBase
    {
        private readonly IFinancialDataService _financialPositionService;

        public FinancialDataController(IFinancialDataService financialPositionService)
        {
            _financialPositionService = financialPositionService;
        }

        [HttpGet]
        [Route("{cikNumber}/{statement}/{position}")]
        // https://localhost:44306/financial-data/CIK0000050863/BalanceSheet/Assets
        public async Task<ActionResult> GetFinancialPositionAsync(
            string cikNumber,
            string statement,
            string position,
            [FromQuery] bool quaterly = false)
        {
            if (!Enum.TryParse(statement, out FinancialStatementType statementType))
            {
                return BadRequest();
            }

            FinancialPositionDynamoItem dynamoItem = await _financialPositionService
                .GetFinancialPosition(cikNumber, statementType, position, quaterly);

            return Ok(dynamoItem);
        }

        [HttpGet]
        [Route("{cikNumber}/{statement}")]
        // https://localhost:44306/financial-data/CIK0000050863/BalanceSheet
        public async Task<ActionResult> GetFinancialPositionsAsync(
            string cikNumber,
            string statement)
        {
            if (!Enum.TryParse(statement, out FinancialStatementType statementType))
            {
                return BadRequest();
            }

            IList<FinancialPositionDynamoItem> dynamoItems = await _financialPositionService
                .GetFinancialPositionsByStatement(cikNumber, statementType);

            return Ok(dynamoItems);
        }
    }
}
