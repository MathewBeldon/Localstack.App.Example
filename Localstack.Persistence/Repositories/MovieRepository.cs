using Amazon.DynamoDBv2;
using Localstack.Application.Interfaces.Persistence;
using Localstack.Domain.Entities;

namespace Localstack.Persistence.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(IAmazonDynamoDB amazonDynamoDB) : base(amazonDynamoDB)
        {
        }
    }
}
