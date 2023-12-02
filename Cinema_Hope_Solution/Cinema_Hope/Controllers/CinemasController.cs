namespace Cinema_Hope.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILocationService _locationService; // Service
        private readonly ICinemaService _cinemaService; // Service
        private readonly IMapper _mapper; // Service


        public CinemasController(ApplicationDbContext context, ILocationService locationService, ICinemaService cinemaService, IMapper mapper)
        {
            _context = context;
            _locationService = locationService;
            _cinemaService = cinemaService;
            _mapper = mapper;
        }

        // GET: Cinemas
        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemaService.GetAllAsync();
            return View(cinemas);
        }



        public IActionResult Details(int id)
        {
            var cinema = _cinemaService.GetById( (int) id);

            if (cinema is null)
                return NotFound();

            return View(cinema);
        }


        [HttpGet]
        public IActionResult Create()
        {
            Create_CinemaViewModel model = new()
            {
                Locations = _locationService.GetSelectListOf_Locations()
            };

            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Create_CinemaViewModel model)
        {
            if (! ModelState.IsValid)
            {
                // after that model is not vaild remember to initialize nessury field of model before return it.

                model.Locations = _locationService.GetSelectListOf_Locations();
                return View(model);
            }

            // let cinema service do create and save to database
            await _cinemaService.Create(model);
           
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Cinema? cinemaInDB = _cinemaService.GetById(id);

            if (cinemaInDB is null)
                return NotFound();

            // pass data to ViewModel From Entity In DB
            Edit_Cinema_ViewModel viewModel = new()
            {
                Name = cinemaInDB.Name,
                Address = cinemaInDB.Address,
                CinemaId = cinemaInDB.CinemaId,
                Email = cinemaInDB.Email,
                LocationId = cinemaInDB.LocationId,
                Phone = cinemaInDB.Phone,
                PostalCode = cinemaInDB.PostalCode,
                Locations = _locationService.GetSelectListOf_Locations()
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Edit_Cinema_ViewModel model )
        {
            if (!ModelState.IsValid)
            {
                // after that model is not vaild remember to initialize nessury field of model before return it.

                model.Locations = _locationService.GetSelectListOf_Locations();
                return View(model);
            }

            // Save Entity To Database using Service : var entity = _service.Edit(model)
            Cinema? cinemaToDB = await _cinemaService.Edit(model);

            // check if entity null , means that BadRequest
            if (cinemaToDB is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _cinemaService.DeleteAsync(id);

            return isDeleted ? Ok() : BadRequest("Bad Requist");
        }

        //======= api
        [HttpGet]
        public async Task<IActionResult> AllCinemas()
        {
            IEnumerable<Cinema> cinemas = await _cinemaService.GetAllAsync();

            IEnumerable<CinemaDto> cinemasDto = _mapper.Map<IEnumerable<CinemaDto>>(cinemas);

            return Ok(cinemasDto);
        }

    }
}
