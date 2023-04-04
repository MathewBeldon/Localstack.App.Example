using MediatR;

namespace Localstack.Application.Features.Movies.Commands.CreateMovie
{
    public sealed record CreateMovieCommandRequest(
        string Title,
        int Year,
        string Director) : IRequest<CreateMovieCommandResponse>;
}
