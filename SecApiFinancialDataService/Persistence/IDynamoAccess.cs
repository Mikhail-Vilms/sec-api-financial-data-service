using SecApiFinancialDataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecApiFinancialDataService.Persistence
{
    public interface IDynamoAccess
    {
        public Task<FinancialPositionDynamoItem> GetFinancialPosition(
            string cikNumber,
            string statementType,
            string positionTitle);
    }
}
