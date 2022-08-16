using SecApiFinancialDataService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecApiFinancialDataService.Services
{
    public interface IFinancialDataService
    {
        public Task<IList<CompanyDynamoItem>> GetListOfCompaniesAsync();

        public Task<CompanyDynamoItem> GetCompanyInfoAsync(string cikNumber);

        public Task<StatementStructureDynamoItem> GetStatementStructureAsync(
            string cikNumber,
            FinancialStatementType statementType);

        public Task<IList<FinancialPositionDynamoItem>> GetFinancialPositionsByStatementAsync(
            string cikNumber,
            FinancialStatementType statementType);

        public Task<FinancialPositionDynamoItem> GetFinancialPositionAsync(
            string cikNumber,
            FinancialStatementType statementType,
            string positionTitle,
            bool quaterly);
    }
}
