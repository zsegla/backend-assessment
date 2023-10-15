using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Contracts
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
    }
}