using MediatR;
using CinemaApp.DTOs.Movie;

namespace CinemaApp.Features.Movies.Requests.Commands
{
    public class CreateMovieCommand : IRequest<MovieDTO>
    {
        public CreateMovieDTO createMovieDTO { get; set; }
    }
}
