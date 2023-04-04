using Amazon;
using Amazon.DynamoDBv2;
using Localstack.Application.Interfaces.Persistence;
using Localstack.Persistence.Helpers;
using Localstack.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Localstack.Persistence
{
    public static class PersistanceServicesRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAmazonDynamoDB>(sc =>
            {
                var dynamoDBConfig = new AmazonDynamoDBConfig
                {
                    RegionEndpoint = RegionEndpoint.GetBySystemName(configuration["AWS:Region"]),
                    ServiceURL = configuration["AWS:DynamoDBServiceURL"]
                };
                var dynamoDbClient = new AmazonDynamoDBClient(dynamoDBConfig);

                DynamoDbInitializer.InitializeTablesAsync(dynamoDbClient).GetAwaiter().GetResult();

                return dynamoDbClient;
            });

            services.AddScoped<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}
