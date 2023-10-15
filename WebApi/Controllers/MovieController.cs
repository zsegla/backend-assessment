using CinemaApp.DTOs.Movie;
using CinemaApp.Features.Movies.Requests.Commands;
using CinemaApp.Features.Movies.Requests.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Movie>> Get()
        {
            var movies = await _mediator.Send(new GetMovieListQuery());
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var movie = await _mediator.Send(new GetMovieDetailQuery { Id = id });
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateMovieDTO movie)
        {
            var command = new CreateMovieCommand { createMovieDTO = movie };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateMovieDTO movie)
        {
            var command = new UpdateMovieCommand { updateMovieDTO = movie };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteMovieCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
