using SecApiFinancialDataService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecApiFinancialDataService.Services
{
    public interface IFinancialDataService
    {
        public Task<FinancialPositionDynamoItem> GetFinancialPosition(
            string cikNumber,
            FinancialStatementType statementType,
            string positionTitle,
            bool quaterly);

        public Task<IList<FinancialPositionDynamoItem>> GetFinancialPositionsByStatement(
            string cikNumber,
            FinancialStatementType statementType);

        public Task<StatementStructureDynamoItem> GetStatementStructure(
            string cikNumber,
            FinancialStatementType statementType);
    }
}
