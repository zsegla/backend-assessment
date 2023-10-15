using AutoMapper;
using FluentValidation;
using CinemaApp.DTOs.Movie;
using CinemaApp.DTOs.Cinema;
using CinemaApp.Exceptions;
using CinemaApp.Features.Cinemas.Requests.Commands;
using CinemaApp.Contracts;
using CinemaApp.Responses;
using CinemaApp.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CinemaApp.DTOs.Cinema.Validators;

namespace CinemaApp.Features.Cinemas.Handlers.Commands
{
    public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICinemaRepository _cinemaRepository;

        public CreateCinemaCommandHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateCinemaDTOValidator();
            var validationResult = await validator.ValidateAsync(request.createCinemaDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var cinema = _mapper.Map<Cinema>(request);
            cinema = await _cinemaRepository.Add(cinema);

            response.Success = true;
            response.Message = "Cinema created successfully";
            response.Id = cinema.Id;

            return response;
        }
    }
}
