using Localstack.Application.Features.Movies.Commands.CreateMovie;
using Localstack.Application.Features.Movies.Queries.GetLatestMovies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Localstack.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public sealed class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator, ILogger<MoviesController> logger)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateMovieCommandResponse>> Create([FromBody] CreateMovieCommandRequest createMovieCommandRequest)
        {
            return Ok(await _mediator.Send(createMovieCommandRequest));
        }

        [HttpGet]
        public async Task<ActionResult<GetLatestMoviesResponse>> List([FromQuery] GetLatestMoviesRequest getLatestMoviesRequest)
        {
            return Ok(await _mediator.Send(getLatestMoviesRequest));
        }
    }
}
