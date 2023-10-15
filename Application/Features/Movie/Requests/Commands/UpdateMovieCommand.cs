using MediatR;
using CinemaApp.DTOs.Movie;

namespace CinemaApp.Features.Movies.Requests.Commands
{
    public class UpdateMovieCommand : IRequest<MovieDTO>
    {
        public UpdateMovieDTO updateMovieDTO { get; set; }
    }
}
