using Microsoft.AspNetCore.Mvc;
using SecApiFinancialDataService.Model;
using SecApiFinancialDataService.Services;
using System;
using System.Threading.Tasks;

namespace SecApiFinancialDataService.Controllers
{
    [Route("financial-statement-structure")]
    [ApiController]
    public class FinancialStatementController : ControllerBase
    {
        private readonly IFinancialDataService _financialPositionService;

        public FinancialStatementController(IFinancialDataService financialPositionService)
        {
            _financialPositionService = financialPositionService;
        }

        [HttpGet]
        [Route("{cikNumber}/{statement}")]
        // https://localhost:44306/financial-statement-structure/CIK0000050863/BalanceSheet
        public async Task<ActionResult> GetStatementStructure(
            string cikNumber,
            string statement)
        {
            if (!Enum.TryParse(statement, out FinancialStatementType statementType))
            {
                return BadRequest();
            }

            StatementStructureDynamoItem dynamoItem = await _financialPositionService
                .GetStatementStructure(cikNumber, statementType);

            return Ok(dynamoItem);
        }
    }
}
