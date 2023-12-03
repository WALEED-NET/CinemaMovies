namespace Cinema_Hope.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShowTimesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IShowTimeService _showTimeService;
        private readonly IMovieService _movieService;
        private readonly IScreenService _screenService;
        private readonly IMapper _mapper;

        public ShowTimesController(ApplicationDbContext context, IShowTimeService showTime, IScreenService screenService, IMovieService movieService, IMapper mapper)
        {
            _context = context;
            _showTimeService = showTime;
            _screenService = screenService;
            _movieService = movieService;
            _mapper = mapper;
        }
        // GET: ShowTimes
        public async Task<IActionResult> Index()
        {
            IEnumerable<ShowTime> showTimes = await _showTimeService.GetAllShowTimesAsync();

            return View(showTimes);
        }


        // GET: ShowTimes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ShowTime? showTime = await _showTimeService.GetByIdAsync(id);

            if (showTime is null)
                return NotFound();

            return View(showTime);
        }



        [HttpGet]
        public IActionResult Create()
        {
            ShowTime_ViewModel model = new ShowTime_ViewModel()
            {
                SelectListOfMovies = _movieService.GetSelectListOf_Movies(),
                SelectListOf_ShowTimeStatus = _showTimeService.GetSelectListOf_ShowTimeStatus(),
                SelectListOfScreens = _screenService.GetSelectListOf_Screens()
            };

            return View(model);
        }



        // POST: ShowTimes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShowTime_ViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // after that model is not vaild remember to initialize nessury field of model before return it.

                model.SelectListOfMovies = _movieService.GetSelectListOf_Movies();
                model.SelectListOf_ShowTimeStatus = _showTimeService.GetSelectListOf_ShowTimeStatus();
                model.SelectListOfScreens = _screenService.GetSelectListOf_Screens();

                return View(model);
            }

            // let ShowTime service do create and save to database

            await _showTimeService.Create(model);

            return RedirectToAction(nameof(Index));

        }



        // GET: ShowTimes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ShowTime? showTimeInDB = await _showTimeService.GetByIdAsync(id);

            if (showTimeInDB is null)
                return NotFound();

            // pass data to ViewModel From Entity In DB
            ShowTime_ViewModel viewModel = _mapper.Map<ShowTime_ViewModel>(showTimeInDB);

            // do not forgot to map other nessary properties to View , like SelectListDropDwon
            viewModel.SelectListOfMovies = _movieService.GetSelectListOf_Movies();
            viewModel.SelectListOf_ShowTimeStatus = _showTimeService.GetSelectListOf_ShowTimeStatus();
            viewModel.SelectListOfScreens = _screenService.GetSelectListOf_Screens();

            return View(viewModel);
        }


        // POST: ShowTimes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ShowTime_ViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // after that model is not vaild remember to initialize nessury field of model before return it.

                model.SelectListOfMovies = _movieService.GetSelectListOf_Movies();
                model.SelectListOf_ShowTimeStatus = _showTimeService.GetSelectListOf_ShowTimeStatus();
                model.SelectListOfScreens = _screenService.GetSelectListOf_Screens();

                return View(model);
            }

            // Edit Entity in Database using Service : var entity = _service.Edit(model)
            ShowTime? showTimeToDB = await _showTimeService.Edit(model);

            // check if entity null , means that BadRequest
            if (showTimeToDB is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _showTimeService.DeleteAsync(id);

            return isDeleted ? Ok() : BadRequest("Bad Request");

        }

        //======= api
        [HttpGet]
        public  IActionResult GetListOfShowTimesByCinemaId(int cinemaId)
        {
            var showTimesByCinemaId = _showTimeService.GetSelectListOf_ShowTimesByCinemaId(cinemaId);

            return Ok(showTimesByCinemaId);
        }
    }
}
