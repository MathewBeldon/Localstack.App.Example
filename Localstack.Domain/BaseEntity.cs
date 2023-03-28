using Amazon.DynamoDBv2.DataModel;

namespace Localstack.Domain
{
    public abstract class BaseEntity
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
    }
}
