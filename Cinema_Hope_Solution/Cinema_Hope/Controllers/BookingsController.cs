namespace Cinema_Hope.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBookingService _bookingService;
        private readonly IShowTimeService _showTimeService;
        private readonly ISeatService _seatService;
        private readonly ICinemaService _cinemaService;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public BookingsController(ApplicationDbContext context, IBookingService bookingService, IShowTimeService showTimeService, ISeatService seatService, IMapper mapper, ICinemaService cinemaService, IMovieService movieService)
        {
            _context = context;
            _bookingService = bookingService;
            _showTimeService = showTimeService;
            _seatService = seatService;
            _mapper = mapper;
            _cinemaService = cinemaService;
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Booking> bookings = await _bookingService.GetAllBookingsAsync();

            return View(bookings);
        }



        public async Task<IActionResult> Details(int id)
        {
            var booking = await _bookingService.GetByIdAsync(id);

            return View(booking);
        }



        [HttpGet]
        public IActionResult Create()
        {
            Booking_ViewModel viewModel = new Booking_ViewModel()
            {
                SelectLisOfCinemas = _cinemaService.GetSelectListOf_Cinemas(),
                SelectLisOfShowTimes = _showTimeService.GetSelectListOf_ShowTimes(),
                SelectLisOfSeats = _seatService.GetSelectListOfSeats(),
                SelectLisOfCustomers = _bookingService.GetSelectListOf_Customers(),
                SelectLisOfBookingStatus = _bookingService.GetSelectListOf_BookingStatus()
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Booking_ViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // after that model is not vaild remember to initialize nessury field of model before return it.

                model.SelectLisOfCinemas = _cinemaService.GetSelectListOf_Cinemas();
                model.SelectLisOfShowTimes = _showTimeService.GetSelectListOf_ShowTimes();
                model.SelectLisOfSeats =  _seatService.GetSelectListOfSeats();
                model.SelectLisOfCustomers = _bookingService.GetSelectListOf_Customers();
                model.SelectLisOfBookingStatus = _bookingService.GetSelectListOf_BookingStatus();

                return View(model);
            }

            // let Booking service do create and save to database

            await _bookingService.Create(model);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Booking? bookingInDB = await _bookingService.GetByIdAsync(id);

            if (bookingInDB is null)
                return NotFound();

            // pass data to ViewModel From Entity In DB
            Booking_ViewModel viewModel = _mapper.Map<Booking_ViewModel>(bookingInDB);

            // do not forgot to map other nessary properties to View , like SelectListDropDwon
            viewModel.SelectLisOfShowTimes = _showTimeService.GetSelectListOf_ShowTimes();
            viewModel.SelectLisOfSeats = _seatService.GetSelectListOfSeats();
            viewModel.SelectLisOfCustomers = _bookingService.GetSelectListOf_Customers();
            viewModel.SelectLisOfBookingStatus = _bookingService.GetSelectListOf_BookingStatus();

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Booking_ViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // after that model is not vaild remember to initialize nessury field of model before return it.

                model.SelectLisOfShowTimes = _showTimeService.GetSelectListOf_ShowTimes();
                model.SelectLisOfSeats = _seatService.GetSelectListOfSeats();
                model.SelectLisOfCustomers = _bookingService.GetSelectListOf_Customers();
                model.SelectLisOfBookingStatus = _bookingService.GetSelectListOf_BookingStatus();

                return View(model);
            }

            // Edit Entity in Database using Service : var entity = _service.Edit(model)
            Booking? bookingToDB = await _bookingService.Edit(model);

            // check if entity null , means that BadRequest
            if (bookingToDB is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }




        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _bookingService.DeleteAsync(id);

            return isDeleted ? Ok() : BadRequest("Bad Request");

        }

        [HttpGet]
        public IActionResult UserBookingMovie(int id)   // movieId
        {
            Page_BookingViewModel viewModel = new Page_BookingViewModel()
            {
                Movie = _movieService.GetById(id)



            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult UserTickets()  
        {
            
            return View();
        }


    }
}
