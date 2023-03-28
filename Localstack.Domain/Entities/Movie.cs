using Amazon.DynamoDBv2.DataModel;

namespace Localstack.Domain.Entities
{
    [DynamoDBTable("Movie")]
    public sealed class Movie : BaseEntity
    {
        [DynamoDBGlobalSecondaryIndexHashKey]
        public string Title { get; set; }

        [DynamoDBGlobalSecondaryIndexHashKey]
        public int Year { get; set; }

        [DynamoDBGlobalSecondaryIndexHashKey]
        public string Director { get; set; }
    }
}
