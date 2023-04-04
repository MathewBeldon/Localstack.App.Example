using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Localstack.Application.Features.Movies.Commands.CreateMovie;
using Localstack.Domain.Entities;
using MediatR;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Localstack.Application.Features.Movies.Queries.GetLatestMovies
{
    internal class GetLatestMoviesHandler : IRequestHandler<GetLatestMoviesRequest, GetLatestMoviesResponse>
    {
        private readonly IAmazonDynamoDB _dynamoDbClient;

        public GetLatestMoviesHandler(IAmazonDynamoDB dynamoDbClient)
        {
            _dynamoDbClient = dynamoDbClient;
        }

        public async Task<GetLatestMoviesResponse> Handle(GetLatestMoviesRequest request, CancellationToken cancellationToken)
        {
            var queryRequest = new QueryRequest
            {
                TableName = "Movie",
                IndexName = $"{nameof(Movie.Description)}-index",
                ExclusiveStartKey = string.IsNullOrEmpty(request.lastEvaluatedKey) ? null : JsonSerializer.Deserialize<Dictionary<string, AttributeValue>>(Convert.FromBase64String(request.lastEvaluatedKey)),
                KeyConditionExpression = "Description = :description",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
                {
                    {":description", new AttributeValue { S = "Movie" } },
                },
                Limit = 4,
                ScanIndexForward = false, // Order by descending
            };

            var queryResponse = await _dynamoDbClient.QueryAsync(queryRequest, cancellationToken);
            
            var movies = queryResponse.Items.Select(item => new MovieDto(
                item["Id"].S,
                item["Title"].S,
                int.Parse(item["Year"].N),
                item["Director"].S)).ToList();

            var lastEvaluatedKey = !queryResponse.LastEvaluatedKey.Any() ? null : Convert.ToBase64String(JsonSerializer.SerializeToUtf8Bytes(
                queryResponse.LastEvaluatedKey,
                new JsonSerializerOptions()
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
                }));

            return new GetLatestMoviesResponse(movies, lastEvaluatedKey);
        }
    }
}
