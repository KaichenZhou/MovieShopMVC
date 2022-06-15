using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class MovieService: IMovieService
    {
        public MovieDetailsModel GetMovieDetails(int id)
        {
            throw new NotImplementedException();
        }

        public MovieDetailsModel GetMovieDetailsModel(int id)
        {
            var movie = new MovieDetailsModel
            {

            };
            return movie;
        }
        //method that return top movies to the caller
        //list of movies
        
        public List<MovieCardModel> GetTopGrossingMovies()
        {
            //call the movie repository to  get the data from database
            var movies = new List<MovieCardModel>
            {
                new MovieCardModel {Id=1,PosterUrl="https://www.imdb.com/title/tt1375666/mediaviewer/rm3426651392/?ref_=tt_ov_i",Title="Inception"},
                new MovieCardModel {Id=2,PosterUrl="",Title=""},
                new MovieCardModel {Id=3,PosterUrl="",Title=""},
                new MovieCardModel {Id=4,PosterUrl="",Title=""},
                new MovieCardModel {Id=5,PosterUrl="",Title=""},

            };
            return movies;
        }


    }
}
