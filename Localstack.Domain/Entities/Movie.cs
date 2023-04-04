using Amazon.DynamoDBv2.DataModel;

namespace Localstack.Domain.Entities
{
    [DynamoDBTable("Movie")]
    public sealed class Movie : BaseEntity
    {

        public string Title { get; set; }

        public int Year { get; set; }

        public string Director { get; set; }
    }
}
