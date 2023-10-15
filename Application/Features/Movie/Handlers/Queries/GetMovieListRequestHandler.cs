using AutoMapper;
using CinemaApp.DTOs.Movie;
using CinemaApp.Features.Movies.Requests.Queries;
using CinemaApp.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CinemaApp.Features.Movies.Handlers.Queries
{
    public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, List<MovieDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public GetMovieListQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieDTO>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetList();
            var movieDTOs = _mapper.Map<List<MovieDTO>>(movies);

            return movieDTOs;
        }
    }
}
