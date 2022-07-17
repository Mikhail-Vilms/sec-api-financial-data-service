using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using SecApiFinancialDataService.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecApiFinancialDataService.Persistence
{
    public class DynamoAccess : IDynamoAccess
    {
        private readonly IDynamoDBContext _dynamoDbContext;

        public DynamoAccess(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        public async Task<FinancialPositionDynamoItem> GetFinancialPosition(
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

        public async Task<IList<FinancialPositionDynamoItem>> GetFinancialPositionsByStatement(
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

        public async Task<StatementStructureDynamoItem> GetStatementStructure(
            string cikNumber,
            FinancialStatementType statementType)
        {
            if (cikNumber == null)
            {
                throw new ArgumentNullException("Next values are required for fetching financial position from Dynamo: [cikNumber, statementType]");
            }

            var sortKeyVal = $"StatementStructure_{statementType}";
            StatementStructureDynamoItem dynamoItem = await _dynamoDbContext
                .LoadAsync<StatementStructureDynamoItem>(
                    cikNumber,
                    $"StatementStructure_{statementType}",
                    default);

            return dynamoItem;
        }
    }
}
