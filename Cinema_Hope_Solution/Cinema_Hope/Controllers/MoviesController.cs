namespace Cinema_Hope.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IGenresService _genresServices;   // Services
        private readonly IMovieService  _movieServices;   // Services

        public MoviesController(ApplicationDbContext context, IGenresService genresServices, IMovieService movieServices)
        {
            _context = context;
            _genresServices = genresServices;
            _movieServices = movieServices;
        }

        public IActionResult Index()
        {
            return View();
        }

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
            await _movieServices.Create(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
