using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> Get30HighestGrossingMovies()
        {
            //Linq code to get the top 30 grossing movies
            //select top 30 * from movie order by Revenue
            var movies =await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public Task <IEnumerable<Movie>> Get30HighestRatedoMovies()
        {
            throw new NotImplementedException();
        }
        public async override Task<Movie> GetById(int id)
        {
            //select * from movie
            //join casr and moviecasr
            //join trailer, genre, and moviegenre
            //where id = id
            var movieDetails =await _dbContext.Movies
                   .Include(m => m.MovieGenres).ThenInclude(m => m.Genre)
                   .Include(m => m.Trailers)
                   .FirstOrDefaultAsync(m => m.Id == id);
            return movieDetails;

        }
    }

}
