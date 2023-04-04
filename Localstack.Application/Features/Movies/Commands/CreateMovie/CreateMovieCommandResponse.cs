using Localstack.Application.Models.Response;

namespace Localstack.Application.Features.Movies.Commands.CreateMovie
{
    public sealed record CreateMovieCommandResponse : ContentResponse<MovieDto>
    {
        public CreateMovieCommandResponse(MovieDto data) : base(data)
        {
        }
    }
}
