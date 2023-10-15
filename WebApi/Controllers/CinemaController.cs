using CinemaApp.DTOs.Cinema;
using CinemaApp.Features.Cinemas.Requests.Commands;
using CinemaApp.Features.Cinemas.Requests.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CinemasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Cinema>> Get()
        {
            var cinemas = await _mediator.Send(new GetCinemaListQuery());
            return Ok(cinemas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cinema>> Get(int id)
        {
            var cinema = await _mediator.Send(new GetCinemaDetailQuery { Id = id });
            return Ok(cinema);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCinema([FromBody] CreateCinemaDTO cinemaDTO)
        {
            var command = new CreateCinemaCommand { createCinemaDTO = cinemaDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCinema([FromBody] UpdateCinemaDTO cinemaDTO)
        {
            var command = new UpdateCinemaCommand { updateCinemaDTO = cinemaDTO };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCinema(int id)
        {
            var command = new DeleteCinemaCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
