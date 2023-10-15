using AutoMapper;
using FluentValidation;
using CinemaApp.DTOs.Cinema;
using CinemaApp.Exceptions;
using CinemaApp.Features.Cinemas.Requests.Commands;
using CinemaApp.Contracts;
using CinemaApp.Responses;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CinemaApp.DTOs.Cinema.Validators;

namespace CinemaApp.Features.Cinemas.Handlers.Commands
{
    public class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICinemaRepository _cinemaRepository;

        public UpdateCinemaCommandHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateCinemaDTOValidator();
            var validationResult = await validator.ValidateAsync(request.updateCinemaDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Update Cinema Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var cinema = await _cinemaRepository.GetDetail(request.updateCinemaDTO.CinemaId);
            if (cinema == null)
            {
                throw new NotFoundException("Cinema", request.updateCinemaDTO.CinemaId);
            }

            _mapper.Map(request.updateCinemaDTO, cinema);
            await _cinemaRepository.Update(cinema);

            response.Success = true;
            response.Message = "Cinema updated successfully";
            response.Id = cinema.Id;

            return response;
        }
    }
}
