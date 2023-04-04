using Amazon.DynamoDBv2.DataModel;

namespace Localstack.Domain
{
    public abstract class BaseEntity
    {
        [DynamoDBHashKey]
        public string Id { get; set; }

        [DynamoDBGlobalSecondaryIndexHashKey]
        public string Description { get; set; }

        [DynamoDBGlobalSecondaryIndexHashKey]
        public long CreatedAtUtcUnixTimestamp { get; set; }

        [DynamoDBIgnore]
        public DateTimeOffset CreatedAtUtc
        {
            get => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUtcUnixTimestamp);
            set => CreatedAtUtcUnixTimestamp = value.ToUnixTimeSeconds();
        }

        public long ModifiedAtUtcUnixTimestamp { get; set; }

        [DynamoDBIgnore]
        public DateTimeOffset ModifiedAtUtc
        {
            get => DateTimeOffset.FromUnixTimeSeconds(ModifiedAtUtcUnixTimestamp);
            set => ModifiedAtUtcUnixTimestamp = value.ToUnixTimeSeconds();
        }
    }
}
