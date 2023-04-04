using Localstack.Application.Features.Movies.Commands.CreateMovie;
using Localstack.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Localstack.Application.Features
{
    [Mapper]
    public partial class MovieMapper
    {
        public partial MovieDto MovieToMovieDto(Movie movie);
    }
}
