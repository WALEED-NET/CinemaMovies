using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Cinema_Hope.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IGenresService _genresServices;   // Services
        private readonly IMovieService _movieService;   // Services
        private readonly IScreenService _screenService;   // Services
        private readonly ICinemaService _cinemaService;   // Services

        public MoviesController(ApplicationDbContext context, IGenresService genresServices, IMovieService movieService, IScreenService screenService, ICinemaService cinemaService)
        {
            _context = context;
            _genresServices = genresServices;
            _movieService = movieService;
            this._screenService = screenService;
            _cinemaService = cinemaService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            IEnumerable<Movie> movies = _movieService.GetAll();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _movieService.GetById(id);

            if (movie is null)
                return NotFound();

            return View(movie);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            Create_MovieForm_ViewModel model = new()
            {
                AllGeners = _genresServices.GetSelectListOf_Genres()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Create_MovieForm_ViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // after that model is not vaild remember to initialize nessury field of model before return it.
                model.AllGeners = _genresServices.GetSelectListOf_Genres();
                    
                return View(model);
            }

            // Save Movie To Database
            // Save Movie Poster To Server.
            await _movieService.Create(model);

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie? movieInDB = _movieService.GetById(id);

            if (movieInDB is null)
                return NotFound();

            // pass data to ViewModel
            Edit_MovieForm_ViewModel viewModel = new()      // will use auto mapper instead of all these lines
            {
                MovieId = id,
                Title = movieInDB.Title,
                Description = movieInDB.Description,
                Director = movieInDB.Director,
                Duration = movieInDB.Duration,
                GenreId = movieInDB.GenreId,
                Language = movieInDB.Language,
                ProductionCompany = movieInDB.ProductionCompany,
                ReleaseDate = movieInDB.ReleaseDate,
                Writers = movieInDB.Writers,
                TrailerUrl = movieInDB.TrailerUrl,
                AllGeners = _genresServices.GetSelectListOf_Genres(),
                CurrentPoster = movieInDB.PosterUrl
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Edit_MovieForm_ViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // after that model is not vaild remember to initialize nessury field of model before return it.
                model.AllGeners = _genresServices.GetSelectListOf_Genres();
                model.CurrentPoster = _movieService.GetById(model.MovieId).PosterUrl ?? "No Movie with Id ";


                return View(model);
            }

            // Save Movie To Database
            // Save Movie Poster To Server.
            var movie = await _movieService.Edit(model);

            if (movie is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _movieService.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }


        public IActionResult AllMovies(string sort, string display)
        {
            // Get all the movies from the database
            var movies = _movieService.GetAll();

            // Apply sorting
            switch (sort)
            {
                case "new":
                    movies = movies.OrderByDescending(m => m.ReleaseDate);
                    break;

                case "old":
                    movies = movies.OrderBy(m => m.ReleaseDate);
                    break;

            }

            // Apply display order
            if (display == "desc")
            {
                movies = movies.Reverse();
            }

            // Create the view model with the filtered and sorted movies
            MoviesPage_ViewModel viewModel = new MoviesPage_ViewModel()
            {
                Movies = movies.ToList(),
                Screens = _screenService.GetSelectListOf_Screens(),
                Cinemas = _cinemaService.GetSelectListOf_Cinemas(),
                Genres = _genresServices.GetSelectListOf_Genres()
            };

            return View(viewModel);
        }


        public IActionResult Filter(string cinema, List<string> genres)
        {
            // Get all the movies from the database
            var movies = _movieService.GetAll();

            // Filter movies by cinema
            //if (!string.IsNullOrEmpty(cinema))
            //{
            //    movies = movies.Where(m => m.Showtimes.Cinema == cinema);
            //}

            // Filter movies by genres
            if (genres != null && genres.Count > 0)
            {
                movies = movies.Where(m =>  genres.Contains(m.Genre.GenreId.ToString()));
            }

            // Create the view model with the filtered movies
            MoviesPage_ViewModel viewModel = new MoviesPage_ViewModel()
            {
                Movies = movies.ToList(),
                Screens = _screenService.GetSelectListOf_Screens(),
                Cinemas = _cinemaService.GetSelectListOf_Cinemas(),
                Genres = _genresServices.GetSelectListOf_Genres()
            };

            return View("AllMovies", viewModel);
        }
    }
}
