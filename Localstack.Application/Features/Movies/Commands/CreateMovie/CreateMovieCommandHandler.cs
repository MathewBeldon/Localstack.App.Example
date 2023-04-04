using Localstack.Application.Interfaces.Persistence;
using Localstack.Domain.Entities;
using MediatR;

namespace Localstack.Application.Features.Movies.Commands.CreateMovie
{
    public sealed class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommandRequest, CreateMovieCommandResponse>
    {
        private readonly IMovieRepository _movieRepository;
        public CreateMovieCommandHandler(
            IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            var movie = new Movie
            {
                Id = Guid.NewGuid().ToString(),
                Title = request.Title,
                Year = request.Year,
                Director = request.Director,
                CreatedAtUtcUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
            };

            var mapper = new MovieMapper();
            var movieDto = mapper.MovieToMovieDto(await _movieRepository.AddAsync(movie, cancellationToken));

            return new CreateMovieCommandResponse(movieDto);
        }
    }
}
