using MediatR;
using CinemaApp.DTOs.Cinema;
using System.Collections.Generic;

namespace CinemaApp.Features.Cinemas.Requests.Queries
{
    public class GetCinemaListQuery : IRequest<List<CinemaDTO>>
    {
    }
}
