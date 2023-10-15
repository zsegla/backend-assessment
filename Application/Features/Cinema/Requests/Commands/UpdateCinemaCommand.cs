using MediatR;
using CinemaApp.DTOs.Cinema;
using CinemaApp.Responses;

namespace CinemaApp.Features.Cinemas.Requests.Commands
{
    public class UpdateCinemaCommand : IRequest<BaseCommandResponse>
    {
        public UpdateCinemaDTO updateCinemaDTO { get; set; }
    }
}
