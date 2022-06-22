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

        public IEnumerable<Movie> Get30HighestGrossingMovies()
        {
            //Linq code to get the top 30 grossing movies
            //select top 30 * from movie order by Revenue
            var movies = _dbContext.Movies.ToList().OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;
        }

        public IEnumerable<Movie> Get30HighestRatedoMovies()
        {
            throw new NotImplementedException();
        }
        public override Movie GetById(int id)
        {
            //select * from movie
            //join casr and moviecasr
            //join trailer, genre, and moviegenre
            //where id = id
            var movieDetails = _dbContext.Movies
                   .Include(m => m.MovieGenres).ThenInclude(m => m.Genre)
                   .Include(m => m.Trailers)
                   .FirstOrDefault(m => m.Id == id);
            return movieDetails;

        }
    }

}
