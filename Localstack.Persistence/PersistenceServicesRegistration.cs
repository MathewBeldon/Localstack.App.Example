﻿using Amazon;
using Amazon.DynamoDBv2;
using Localstack.Application.Interfaces.Persistence;
using Localstack.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Localstack.Persistence
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAmazonDynamoDB>(sc =>
            {
                var dynamoDBConfig = new AmazonDynamoDBConfig
                {
                    RegionEndpoint = RegionEndpoint.GetBySystemName(configuration["AWS:Region"]),
                    ServiceURL = configuration["AWS:DynamoDBServiceURL"]
                };

                return new AmazonDynamoDBClient(dynamoDBConfig);
            });

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}