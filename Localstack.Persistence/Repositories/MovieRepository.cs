using Localstack.Application.Interfaces.Persistence;
using Localstack.Domain.Entities;

namespace Localstack.Persistence.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
    }
}
