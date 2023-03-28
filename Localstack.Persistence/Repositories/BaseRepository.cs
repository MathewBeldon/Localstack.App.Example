using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Localstack.Application.Interfaces.Persistence;
using Localstack.Domain;

namespace Localstack.Persistence.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AmazonDynamoDBClient _client;
        private readonly DynamoDBContext _context;

        public BaseRepository()
        {
            _client = new AmazonDynamoDBClient();
            _context = new DynamoDBContext(_client);
        }

        public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _context.LoadAsync<T>(id, cancellationToken);
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.SaveAsync(entity, cancellationToken);
            return entity;
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.SaveAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.DeleteAsync(entity, cancellationToken);
        }
    }
}
