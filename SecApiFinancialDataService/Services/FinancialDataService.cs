using SecApiFinancialDataService.Model;
using SecApiFinancialDataService.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecApiFinancialDataService.Services
{
    public class FinancialDataService : IFinancialDataService
    {
        private readonly IDynamoAccess _dynamoAccess;

        public FinancialDataService(IDynamoAccess dynamoAccess)
        {
            _dynamoAccess = dynamoAccess;
        }

        public async Task<FinancialPositionDynamoItem> GetFinancialPosition(
            string cikNumber,
            FinancialStatementType statementType,
            string positionTitle)
        {
            return await _dynamoAccess.GetFinancialPosition(
                cikNumber,
                statementType,
                positionTitle);
        }

        public async Task<IList<FinancialPositionDynamoItem>> GetFinancialPositionsByStatement(
            string cikNumber,
            FinancialStatementType statementType)
        {
            return await _dynamoAccess.GetFinancialPositionsByStatement(
                cikNumber,
                statementType);
        }

        public async Task<StatementStructureDynamoItem> GetStatementStructure(
            string cikNumber,
            FinancialStatementType statementType)
        {
            return await _dynamoAccess.GetStatementStructure(
                cikNumber,
                statementType);
        }
    }
}
