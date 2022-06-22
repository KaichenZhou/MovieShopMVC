using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepostiory;

        public MovieService(IMovieRepository movieRepostiory)
        {
            _movieRepostiory = movieRepostiory;
        }
        public MovieDetailsModel GetMovieDetails(int id)
        {
            var movieDetails = _movieRepostiory.GetById(id);



            var movie = new MovieDetailsModel
            {
                //all these prop will be displayed on the movie detail page
                //from movie table
                Id = movieDetails.Id,
                Tagline = movieDetails.Tagline,
                Title = movieDetails.Title,
                PosterUrl = movieDetails.PosterUrl,
                BackdropUrl = movieDetails.BackdropUrl,
                ImdbUrl = movieDetails.ImdbUrl,
                RunTime = movieDetails.RunTime,
                TmdbUrl = movieDetails.TmdbUrl,
                Revenue = movieDetails.Revenue,
                Budget = movieDetails.Budget,
                ReleaseDate = movieDetails.ReleaseDate,
                Overview = movieDetails.Overview,

            };
            foreach (var genre in movieDetails.MovieGenres)
            {
                movie.Genres.Add(new GenreModel { Id = genre.Genre.Id, Name = genre.Genre.Name });
            }
            /*
            foreach (var cast in movieDetails.MovieCasts)
            {
                movie.Casts.Add(new CastModel { Id = cast.CastId, 
                                                Name = cast.Cast.Name,
                                                Character = cast.Character, 
                                                ProfilePath = cast.Cast.ProfilePath });
            }
            */


            foreach (var trailer in movieDetails.Trailers)
            {
                movie.Trailers.Add(new TrailerModel
                {
                    Id = trailer.Id,
                    Name = trailer.Name,
                    TrailerUrl = trailer.TrailerUrl
                });
            }
            return movie;


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
            /*
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
            */
            var movies = _movieRepostiory.Get30HighestGrossingMovies();
            var movieCards = new List<MovieCardModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title });
            }
            return movieCards;

        }


    }
}
