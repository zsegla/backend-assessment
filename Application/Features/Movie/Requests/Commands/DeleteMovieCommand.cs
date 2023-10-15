using MediatR;
using CinemaApp.Responses;

namespace CinemaApp.Features.Movies.Requests.Commands
{
    public class DeleteMovieCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
