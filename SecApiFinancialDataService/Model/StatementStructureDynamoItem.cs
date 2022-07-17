﻿using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace SecApiFinancialDataService.Model
{
    public class StatementStructureDynamoItem
    {
        [DynamoDBTable("Sec-Api-Financial-Data")]
        public class FinancialPositionDynamoItem
        {
            [DynamoDBHashKey("PartitionKey")]
            public string PartitionKey { get; set; }

            [DynamoDBRangeKey("SortKey")]
            public string SortKey { get; set; }

            // [DynamoDBProperty("FinancialPositions")]
            // public List<FinancialPositionDescription> FinancialPositions { get; set; }
        }
    }

    public class FinancialPositionDescription
    {
        // public List<string> Children { get; set; }
        public string FullLabel { get; set; }
        public string Name { get; set; }
    }
}
