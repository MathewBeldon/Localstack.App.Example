using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Localstack.Application.Interfaces.Persistence;
using Localstack.Domain;
using Amazon.DynamoDBv2.Model;
using System.Reflection;

namespace Localstack.Persistence.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly IAmazonDynamoDB _dynamoDbClient;
        private readonly DynamoDBContext _dbContext;

        public BaseRepository(IAmazonDynamoDB amazonDynamoDB)
        {
            _dynamoDbClient = amazonDynamoDB;
            _dbContext = new DynamoDBContext(_dynamoDbClient);
        }

        public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _dbContext.LoadAsync<T>(id, cancellationToken);
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            entity.CreatedAtUtc = DateTime.UtcNow;
            entity.Description = entity.GetType().Name;
            await _dbContext.SaveAsync(entity, cancellationToken);
            return entity;
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbContext.SaveAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbContext.DeleteAsync(entity, cancellationToken);
        }
    }
}
