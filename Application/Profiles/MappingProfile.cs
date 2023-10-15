using AutoMapper;
using CinemaApp.DTOs.Movie;
using CinemaApp.DTOs.Cinema;
using Domain.Entities;

namespace CinemaApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, CreateMovieDTO>().ReverseMap();
            CreateMap<Movie, UpdateMovieDTO>().ReverseMap();
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Cinema, CreateCinemaDTO>().ReverseMap();
            CreateMap<Cinema, UpdateCinemaDTO>().ReverseMap();
            CreateMap<Cinema, CinemaDTO>().ReverseMap();
        }
    }
}
