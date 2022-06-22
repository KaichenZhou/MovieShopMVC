using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Views.Shared.Components.Genres
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly IGenreService _genreService;

        public GenresViewComponent(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public IViewComponentResult Invoke()
        {
            var genres = _genreService.GetAllGenres();
            return View(genres);
        }
    }
}
