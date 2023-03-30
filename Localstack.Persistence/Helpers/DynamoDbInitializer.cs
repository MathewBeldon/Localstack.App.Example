using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2;

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
                new AttributeDefinition("Id", ScalarAttributeType.S),
                new AttributeDefinition("Title", ScalarAttributeType.S),
                new AttributeDefinition("Year", ScalarAttributeType.N),
                new AttributeDefinition("Director", ScalarAttributeType.S),
            },
                KeySchema = new List<KeySchemaElement>
            {
                new KeySchemaElement("Id", KeyType.HASH),
            },
                GlobalSecondaryIndexes = new List<GlobalSecondaryIndex>
            {
                new GlobalSecondaryIndex
                {
                    IndexName = "Title-index",
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement("Title", KeyType.HASH),
                    },
                    Projection = new Projection
                    {
                        ProjectionType = ProjectionType.ALL
                    },
                    ProvisionedThroughput = new ProvisionedThroughput(5, 5)
                },
                new GlobalSecondaryIndex
                {
                    IndexName = "Year-index",
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement("Year", KeyType.HASH),
                    },
                    Projection = new Projection
                    {
                        ProjectionType = ProjectionType.ALL
                    },
                    ProvisionedThroughput = new ProvisionedThroughput(5, 5)
                },
                new GlobalSecondaryIndex
                {
                    IndexName = "Director-index",
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement("Director", KeyType.HASH),
                    },
                    Projection = new Projection
                    {
                        ProjectionType = ProjectionType.ALL
                    },
                    ProvisionedThroughput = new ProvisionedThroughput(5, 5)
                }
            },
                ProvisionedThroughput = new ProvisionedThroughput(5, 5),
            };

            await dynamoDbClient.CreateTableAsync(request);
        }
    }
}
