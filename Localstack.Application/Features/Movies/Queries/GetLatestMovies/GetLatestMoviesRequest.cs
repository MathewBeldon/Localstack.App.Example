using MediatR;

namespace Localstack.Application.Features.Movies.Queries.GetLatestMovies
{
    public record GetLatestMoviesRequest(
        string? lastEvaluatedKey) : IRequest<GetLatestMoviesResponse>;
}
