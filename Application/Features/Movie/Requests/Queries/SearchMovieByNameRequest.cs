using MediatR;
using CinemaApp.DTOs.Movie;
using System.Collections.Generic;

namespace CinemaApp.Features.Movies.Requests.Queries
{
    public class SearchMovieQuery : IRequest<List<MovieDTO>>
    {
        public string SearchTerm { get; set; }
    }
}
