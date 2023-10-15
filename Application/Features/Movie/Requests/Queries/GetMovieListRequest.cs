using MediatR;
using CinemaApp.DTOs.Movie;
using System.Collections.Generic;

namespace CinemaApp.Features.Movies.Requests.Queries
{
    public class GetMovieListQuery : IRequest<List<MovieDTO>>
    {
    }
}
