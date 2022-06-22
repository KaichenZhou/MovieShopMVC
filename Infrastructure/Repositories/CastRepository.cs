using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repositories
{
    public class CastRepository : Repository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }

        public override Cast GetById(int id)
        {
            var castDetails = _dbContext.Casts
                .Include(m => m.MovieCasts).ThenInclude(m => m.Movie)
                .FirstOrDefault(m => m.Id == id);

            return castDetails;
        }
    }
}
