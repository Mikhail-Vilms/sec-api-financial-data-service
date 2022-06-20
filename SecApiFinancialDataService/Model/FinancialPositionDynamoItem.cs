using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace SecApiFinancialDataService.Model
{
    [DynamoDBTable("Sec-Api-Financial-Data")]
    public class FinancialPositionDynamoItem
    {
        [DynamoDBHashKey("PartitionKey")]
        public string PartitionKey { get ; set; }
        [DynamoDBRangeKey("SortKey")]
        public string SortKey { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string Taxanomy { get; set; }
        public string TickerSymbol { get; set; }

        public List<SecFact> Facts { get; set; }
    }

    public class SecFact
    {
        public string EndDate { get; set; }
        public string Form { get; set; }
        public string Frame { get; set; }
        public string StartDate { get; set; }
        public string Value { get; set; }
    }
}
