﻿using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // showing details of the movie
        public async Task<IActionResult> Details(int id)
        {
            var movies =await _movieService.GetMovieDetails(id);
            return View(movies);
        }

       
    }
}