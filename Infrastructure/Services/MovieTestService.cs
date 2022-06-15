using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieTestService : IMovieService

    {
        public MovieDetailsModel GetMovieDetails(int id)
        {
            throw new NotImplementedException();
        }

        public MovieDetailsModel GetMovieDetailsModel(int id)
             
        {
            throw new NotImplementedException();
        }
        List<MovieCardModel> IMovieService.GetTopGrossingMovies()
        {
            var movies = new List<MovieCardModel>
            {
                new MovieCardModel {Id=11,PosterUrl="https://www.imdb.com/title/tt1375666/mediaviewer/rm3426651392/?ref_=tt_ov_i",Title="Inception"},
                new MovieCardModel {Id=12,PosterUrl="",Title=""},
                new MovieCardModel {Id=13,PosterUrl="",Title=""},
                new MovieCardModel {Id=14,PosterUrl="",Title=""},
                new MovieCardModel {Id=15,PosterUrl="",Title=""},

            };
            return movies;
        }
    }
}


