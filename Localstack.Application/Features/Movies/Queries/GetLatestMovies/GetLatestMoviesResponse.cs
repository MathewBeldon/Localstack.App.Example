using Localstack.Application.Features.Movies.Commands.CreateMovie;
using Localstack.Application.Models.Response;

namespace Localstack.Application.Features.Movies.Queries.GetLatestMovies
{
    public sealed record GetLatestMoviesResponse : PaginationResponse<MovieDto>
    {
        public GetLatestMoviesResponse(IReadOnlyList<MovieDto> data, string? lastEvaluatedKey) : base(data, lastEvaluatedKey)
        {
            
        }
    }
}
