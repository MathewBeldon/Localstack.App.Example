using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2;
using Localstack.Domain.Entities;

namespace Localstack.Persistence.Helpers
{
    internal static class DynamoDbInitializer
    {
        public static async Task InitializeTablesAsync(IAmazonDynamoDB dynamoDbClient)
        {
            var tables = await dynamoDbClient.ListTablesAsync();
            if (!tables.TableNames.Contains("Movie"))
            {
                await CreateMovieTableAsync(dynamoDbClient);
            }
        }

        private static async Task CreateMovieTableAsync(IAmazonDynamoDB dynamoDbClient)
        {
            var request = new CreateTableRequest
            {
                TableName = "Movie",
                AttributeDefinitions = new List<AttributeDefinition>
                {
                    new AttributeDefinition(nameof(Movie.Id), ScalarAttributeType.S),
                    new AttributeDefinition(nameof(Movie.Description), ScalarAttributeType.S),
                    new AttributeDefinition(nameof(Movie.CreatedAtUtcUnixTimestamp), ScalarAttributeType.N),

                },
                    KeySchema = new List<KeySchemaElement>
                {
                    new KeySchemaElement(nameof(Movie.Id), KeyType.HASH),
                },
                GlobalSecondaryIndexes = new List<GlobalSecondaryIndex>
                {
                    new GlobalSecondaryIndex
                    {
                        IndexName = $"{nameof(Movie.Description)}-index",
                        KeySchema = new List<KeySchemaElement>
                        {
                            new KeySchemaElement(nameof(Movie.Description), KeyType.HASH),
                            new KeySchemaElement(nameof(Movie.CreatedAtUtcUnixTimestamp), KeyType.RANGE),
                        },
                        Projection = new Projection
                        {
                            ProjectionType = ProjectionType.ALL
                        },
                        ProvisionedThroughput = new ProvisionedThroughput(5, 5)
                    },
                },
                ProvisionedThroughput = new ProvisionedThroughput(5, 5),
            };

            await dynamoDbClient.CreateTableAsync(request);
        }
    }
}
