using Cinema_Hope.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cinema_Hope.Controllers
{
    [Authorize(Roles = "Admin")]

    public class SeatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISeatService _seatService;
        private readonly IScreenService _screenService;
        private readonly IMapper _mapper;


        public SeatsController(ApplicationDbContext context, ISeatService seatService, IScreenService screenService, IMapper mapper)
        {
            _context = context;
            _seatService = seatService;
            _screenService = screenService;
            _mapper = mapper;
        }

        // GET: Seats
        public async Task<IActionResult> Index()
        {
            IEnumerable<Seat> seats = await _seatService.GetAllSeatsAsync();

            return View(seats);
        }



        // GET: Seats/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Seat? seat = await _seatService.GetByIdAsync(id);

            if (seat is null)
                return NotFound();

            return View(seat);
        }


        [HttpGet]
        public IActionResult Create()
        {
            SeatFrom_ViewModel viewModel = new()
            {
                SelectListOfScreens = _screenService.GetSelectListOf_Screens()
            };

            return View(viewModel);
        }


        // POST: Seats/Create.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SeatFrom_ViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // after that model is not vaild remember to initialize nessury field of model before return it.

                model.SelectListOfScreens = _screenService.GetSelectListOf_Screens();

                return View(model);
            }

            // let seat service do create and save to database

            await _seatService.Create(model);

            return RedirectToAction(nameof(Index));
        }


        // GET: Seats/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Seat? seatInDB = await _seatService.GetByIdAsync(id);

            if (seatInDB is null)
                return NotFound();

            // pass data to ViewModel From Entity In DB
            SeatFrom_ViewModel viewModel = _mapper.Map<SeatFrom_ViewModel>(seatInDB);

            // do not forgot to map other nessary properties to View , like SelectListDropDwon
            viewModel.SelectListOfScreens = _screenService.GetSelectListOf_Screens();

            return View(viewModel);
        }


        // POST: Seats/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SeatFrom_ViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // after that model is not vaild remember to initialize nessury field of model before return it.

                model.SelectListOfScreens = _screenService.GetSelectListOf_Screens();

                return View(model);
            }

            // Edit Entity in Database using Service : var entity = _service.Edit(model)
            Seat? seatToDB = await _seatService.Edit(model);

            // check if entity null , means that BadRequest
            if (seatToDB is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _seatService.DeleteAsync(id);

            return isDeleted ? Ok() : BadRequest("Bad Request");

        }
    }
}
