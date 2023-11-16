using Cinema_Hope.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinema_Hope.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController( IMovieService movieService )
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> movies = _movieService.GetAll();
            return View(movies);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}