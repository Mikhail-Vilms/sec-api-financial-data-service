using Amazon.DynamoDBv2.DataModel;
using SecApiFinancialDataService.Model;
using System;
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
            string statementType,
            string positionTitle)
        {
            if (cikNumber == null || statementType == null || positionTitle == null)
            {
                throw new ArgumentNullException("Next values are required for fetching financial position from Dynamo: [cikNumber, statementType, position]");
            }

            FinancialPositionDynamoItem dynamoItem = await _dynamoDbContext
                .LoadAsync<FinancialPositionDynamoItem>(cikNumber, $"{statementType}_{positionTitle}", default);

            return dynamoItem;
        }
    }
}
