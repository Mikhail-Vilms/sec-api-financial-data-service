using SecApiFinancialDataService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecApiFinancialDataService.Persistence
{
    /// <summary>
    /// Contract for all dynamo table operations
    /// </summary>
    public interface IDynamoAccess
    {
        /// <summary>
        /// Fetches a list of objects that contains information about all companies
        /// </summary>
        public Task<IList<CompanyDynamoItem>> GetListOfCompaniesAsync();

        /// <summary>
        /// Fetches dynamo item that contains information about specific company
        /// </summary>
        public Task<CompanyDynamoItem> GetCompanyInfoAsync(string cikNumber);

        /// <summary>
        /// Fetches json that reflects the structure of a specific financial statement by company's identifier and statement title
        /// </summary>
        /// <param name="cikNumber">
        /// Company's identifier - CIK number
        /// </param>
        /// <param name="statementType">
        /// Type of the financial statement
        /// </param>
        public Task<StatementStructureDynamoItem> GetStatementStructureAsync(
            string cikNumber,
            FinancialStatementType statementType);

        /// <summary>
        /// Fetches datasets for all financial positions for a given financial statement
        /// </summary>
        /// <param name="cikNumber">
        /// Company's identifier - CIK number
        /// </param>
        /// <param name="statementType">
        /// Type of the financial statement
        /// </param>
        public Task<IList<FinancialPositionDynamoItem>> GetFinancialPositionsByStatementAsync(
            string cikNumber,
            FinancialStatementType statementType);

        /// <summary>
        /// Fetches dataset for a specific financial position
        /// </summary>
        /// <param name="cikNumber">
        /// Company's identifier - CIK number
        /// </param>
        /// <param name="statementType">
        /// Type of the financial statement
        /// </param>
        /// <param name="positionTitle">
        /// Financial position's full title - according to XBRL format
        /// </param>
        public Task<FinancialPositionDynamoItem> GetFinancialPositionAsync(
            string cikNumber,
            FinancialStatementType statementType,
            string positionTitle);
    }
}
