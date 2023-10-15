using FluentValidation;

namespace CinemaApp.DTOs.Cinema.Validators;
public class UpdateCinemaDTOValidator : AbstractValidator<UpdateCinemaDTO>
{
    public UpdateCinemaDTOValidator()
    {
        RuleFor(dto => dto.CinemaId)
            .NotEmpty().WithMessage("CinemaId is needed!");

    }
}