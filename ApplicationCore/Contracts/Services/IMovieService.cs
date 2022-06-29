using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        //all the business fucntionality methods pertaining to Moives

        //MovieModel GetMovieDetails(int movieID)
        Task<List<MovieCardModel>> GetTopGrossingMovies();

        // get movie details
         Task<MovieDetailsModel> GetMovieDetails(int id);

        Task<MovieDetailsModel> GetTopRatedMovies();
        //List<MovieCardModel> GetTopGrossingMovies();
        //get movie details;
        //MovieDetailsModel GetMovieDetails(int id);
        Task<PagedResultSetModel<MovieCardModel>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageNumber = 1);
    }
}
