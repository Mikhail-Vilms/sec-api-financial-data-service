using SecApiFinancialDataService.Model;
using SecApiFinancialDataService.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecApiFinancialDataService.Services
{
    public class FinancialPositionService : IFinancialPositionService
    {
        private readonly IDynamoAccess _dynamoAccess;

        public FinancialPositionService(IDynamoAccess dynamoAccess)
        {
            _dynamoAccess = dynamoAccess;
        }

        public async Task<FinancialPositionDynamoItem> GetFinancialPosition(
            string cikNumber,
            string statementType,
            string positionTitle)
        {
            return await _dynamoAccess.GetFinancialPosition(
                cikNumber,
                statementType,
                positionTitle);
        }
    }
}
