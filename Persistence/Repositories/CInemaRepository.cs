using CinemaApp.Application.Contracts;
using CinemaApp.Domain.Entities;
using CinemaApp.Persistence;
using CinemaApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Persistence.Repositories
{
    public class CinemaRepository : GenericRepository<Cinema>, ICinemaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CinemaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
