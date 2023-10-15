using MediatR;
using CinemaApp.DTOs.Cinema;
using CinemaApp.Responses;

namespace CinemaApp.Features.Cinemas.Requests.Commands
{
    public class CreateCinemaCommand : IRequest<BaseCommandResponse>
    {
        public CreateCinemaDTO createCinemaDTO { get; set; }
    }
}
