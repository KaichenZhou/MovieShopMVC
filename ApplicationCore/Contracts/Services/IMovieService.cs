﻿using ApplicationCore.Models;
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


        //List<MovieCardModel> GetTopGrossingMovies();
        //get movie details;
        //MovieDetailsModel GetMovieDetails(int id);
    }
}
