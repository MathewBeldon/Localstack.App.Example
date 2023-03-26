using Localstack.Domain.Entities;
using MediatR;

namespace Localstack.Application.Features.Movies.Commands.CreateMovie
{
    public sealed record CreateMovieCommandRequest(Movie Movie) : IRequest<CreateMovieCommandResponse>;
    
}
