using MediatR;
using CinemaApp.DTOs.Movie;

namespace CinemaApp.Features.Movies.Requests.Queries
{
    public class GetMovieDetailQuery : IRequest<MovieDTO>
    {
        public int Id { get; set; }
    }
}
