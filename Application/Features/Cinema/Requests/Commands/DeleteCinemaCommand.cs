using MediatR;
using CinemaApp.Responses;

namespace CinemaApp.Features.Cinemas.Requests.Commands
{
    public class DeleteCinemaCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
