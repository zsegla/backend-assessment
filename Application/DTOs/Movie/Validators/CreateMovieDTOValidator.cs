using CinemaApp.DTOs.Movie;
using FluentValidation;

namespace CinemaApp.DTOs.Movie.Validators;

public class CreateMovieDTOValidator : AbstractValidator<CreateMovieDTO>
{
    public CreateMovieDTOValidator()
    {
        RuleFor(dto => dto.Title)
            .NotEmpty().WithMessage("Title is required!")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(dto => dto.Genre)
            .NotEmpty().WithMessage("Genre is required.")
            .MaximumLength(20).WithMessage("Genre cannot exceed 20 characters!");

        RuleFor(dto => dto.ReleaseYear)
            .NotEmpty().WithMessage("Release year is required!")
            .GreaterThanOrEqualTo(1800).WithMessage("Release year must be 1800 or later!");


        RuleFor(dto => dto.MovieLength)
            .NotEmpty().WithMessage("Movie length is required!")
            .GreaterThan(0).WithMessage("Movie length must be greater than 0!");

        RuleFor(dto => dto.Plot)
            .NotEmpty().WithMessage("Plot required!")
            .MaximumLength(1000).WithMessage("Plot cannot exceed 1000 characters!");
    }
}
