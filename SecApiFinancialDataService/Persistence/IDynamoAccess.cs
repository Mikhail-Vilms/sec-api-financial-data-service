using SecApiFinancialDataService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecApiFinancialDataService.Persistence
{
    public interface IDynamoAccess
    {
        public Task<FinancialPositionDynamoItem> GetFinancialPosition(
            string cikNumber,
            FinancialStatementType statementType,
            string positionTitle);

        public Task<IList<FinancialPositionDynamoItem>> GetFinancialPositionsByStatement(
            string cikNumber,
            FinancialStatementType statementType);

        public Task<StatementStructureDynamoItem> GetStatementStructure(
            string cikNumber,
            FinancialStatementType statementType);
    }
}
