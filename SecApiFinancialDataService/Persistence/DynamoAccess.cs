using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using SecApiFinancialDataService.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecApiFinancialDataService.Persistence
{
    /// <summary>
    /// Implementation of all operations with dynamo tables
    /// </summary>
    public class DynamoAccess : IDynamoAccess
    {
        private readonly IDynamoDBContext _dynamoDbContext;

        public DynamoAccess(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        /// <inheritdoc />
        public async Task<IList<CompanyDynamoItem>> GetListOfCompaniesAsync()
        {
            IList<CompanyDynamoItem> dynamoItems = await _dynamoDbContext
                .QueryAsync<CompanyDynamoItem>("LIST_OF_COMPANIES")
                .GetRemainingAsync();

            return dynamoItems;
        }

        /// <inheritdoc />
        public async Task<StatementStructureDynamoItem> GetStatementStructureAsync(
            string cikNumber,
            FinancialStatementType statementType)
        {
            if (cikNumber == null)
            {
                throw new ArgumentNullException("Next values are required for fetching financial position from Dynamo: [cikNumber, statementType]");
            }

            StatementStructureDynamoItem dynamoItem = await _dynamoDbContext
                .LoadAsync<StatementStructureDynamoItem>(
                    cikNumber,
                    $"StatementStructure_{statementType}",
                    default);

            return dynamoItem;
        }

        /// <inheritdoc />
        public async Task<FinancialPositionDynamoItem> GetFinancialPositionAsync(
            string cikNumber,
            FinancialStatementType statementType,
            string positionTitle)
        {
            if (cikNumber == null || positionTitle == null)
            {
                throw new ArgumentNullException("Next values are required for fetching financial position from Dynamo: [cikNumber, statementType, position]");
            }

            FinancialPositionDynamoItem dynamoItem = await _dynamoDbContext
                .LoadAsync<FinancialPositionDynamoItem>(
                    cikNumber,
                    $"{statementType}_{positionTitle}",
                    default);

            return dynamoItem;
        }

        /// <inheritdoc />
        public async Task<IList<FinancialPositionDynamoItem>> GetFinancialPositionsByStatementAsync(
            string cikNumber,
            FinancialStatementType statementType)
        {
            if (cikNumber == null)
            {
                throw new ArgumentNullException("Next values are required for fetching financial position from Dynamo: [cikNumber]");
            }

            IList<FinancialPositionDynamoItem> dynamoItems = await _dynamoDbContext
                .QueryAsync<FinancialPositionDynamoItem>(
                    cikNumber,
                    QueryOperator.BeginsWith,
                    new List<string>() { statementType.ToString() + "_" })
                .GetRemainingAsync();

            return dynamoItems;
        }
    }
}
