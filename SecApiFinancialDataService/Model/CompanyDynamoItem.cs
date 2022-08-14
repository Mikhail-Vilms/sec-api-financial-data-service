using Amazon.DynamoDBv2.DataModel;

namespace SecApiFinancialDataService.Model
{
    [DynamoDBTable("Sec-Api-Financial-Data")]
    public class CompanyDynamoItem
    {
        [DynamoDBHashKey("PartitionKey")]
        public string PartitionKey { get; set; }

        [DynamoDBRangeKey("SortKey")]
        public string SortKey { get; set; }

        public bool IsActive { get; set; }
        public string CikNumber { get; set; }
        public string Title { get; set; }
    }
}
