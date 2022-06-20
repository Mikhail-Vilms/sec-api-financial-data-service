using SecApiFinancialDataService.Model;
using System.Threading.Tasks;

namespace SecApiFinancialDataService.Services
{
    public interface IFinancialPositionService
    {
        public Task<FinancialPositionDynamoItem> GetFinancialPosition(
            string cikNumber,
            string statementType,
            string positionTitle);
    }
}
