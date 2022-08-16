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

        public async Task<IList<CompanyDynamoItem>> GetListOfCompaniesAsync()
        {
            return await _dynamoAccess.GetListOfCompaniesAsync();
        }

        public async Task<CompanyDynamoItem> GetCompanyInfoAsync(string cikNumber)
        {
            return await _dynamoAccess.GetCompanyInfoAsync(cikNumber);
        }

        public async Task<FinancialPositionDynamoItem> GetFinancialPositionAsync(
            string cikNumber,
            FinancialStatementType statementType,
            string positionTitle,
            bool quaterly)
        {
            FinancialPositionDynamoItem financialPositionDynamoItem = await _dynamoAccess.GetFinancialPositionAsync(
                cikNumber,
                statementType,
                positionTitle);

            financialPositionDynamoItem.Facts = quaterly ? 
                financialPositionDynamoItem.Facts.Take(12).ToList() :
                financialPositionDynamoItem.Facts.Where(fact => fact.Frame.Contains("Q4I")).Take(12).ToList();

            return financialPositionDynamoItem;
        }

        public async Task<IList<FinancialPositionDynamoItem>> GetFinancialPositionsByStatementAsync(
            string cikNumber,
            FinancialStatementType statementType)
        {
            return await _dynamoAccess.GetFinancialPositionsByStatementAsync(
                cikNumber,
                statementType);
        }

        public async Task<StatementStructureDynamoItem> GetStatementStructureAsync(
            string cikNumber,
            FinancialStatementType statementType)
        {
            return await _dynamoAccess.GetStatementStructureAsync(
                cikNumber,
                statementType);
        }
    }
}
