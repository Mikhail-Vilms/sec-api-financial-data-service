using SecApiFinancialDataService.Model;
using SecApiFinancialDataService.Persistence;
using System.Collections.Generic;
using System.Linq;
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
            string positionTitle,
            bool quaterly)
        {
            FinancialPositionDynamoItem financialPositionDynamoItem = await _dynamoAccess.GetFinancialPosition(
                cikNumber,
                statementType,
                positionTitle);

            financialPositionDynamoItem.Facts = quaterly ? 
                financialPositionDynamoItem.Facts.Take(12).ToList() :
                financialPositionDynamoItem.Facts.Where(fact => fact.Frame.Contains("Q1I")).Take(12).ToList();

            return financialPositionDynamoItem;
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
