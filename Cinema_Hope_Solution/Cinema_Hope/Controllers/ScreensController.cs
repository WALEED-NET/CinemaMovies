using Cinema_Hope.Enums;
using Cinema_Hope.Models;

namespace Cinema_Hope.Controllers
{
    public class ScreensController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICinemaService _cinemaService; // Service
        private readonly IScreenService _screenService; // Service

        public ScreensController(ApplicationDbContext context, ICinemaService cinemaService, IScreenService screenService)
        {
            _context = context;
            _cinemaService = cinemaService;
            _screenService = screenService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Screen> screens = await _screenService.GetAllScreensAsync();

            return View(screens);
        }

        // GET: Screens/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Screen? screen = await _screenService.GetByIdAsync( id );

            if (screen is null)
                return NotFound();

            return View(screen);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ScreenFrom_ViewModel model = new()
            {
                ScreenTypes = _screenService.GetSelectListOf_ScreenType(),
                Cinemas = _cinemaService.GetSelectListOf_Cinemas()
            };

            return View(model);

        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ScreenFrom_ViewModel model )
        {

            if (!ModelState.IsValid)
            {
                // after that model is not vaild remember to initialize nessury field of model before return it.

                model.ScreenTypes = _screenService.GetSelectListOf_ScreenType();
                model.Cinemas = _cinemaService.GetSelectListOf_Cinemas();

                return View(model);
            }

            // let screen service do create and save to database

            await _screenService.Create(model);

            return RedirectToAction(nameof(Index));

            //if (ModelState.IsValid)
            //{
            //    _context.Add(screen);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["CinemaId"] = new SelectList(_context.Cinemas, "CinemaId", "Name", screen.CinemaId);
            //return View(screen)
        }



        // GET: Screens/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Screen? screenInDB = await _screenService.GetByIdAsync(id);

            if (screenInDB is null)
                return NotFound();

            // pass data to ViewModel From Entity In DB
            ScreenFrom_ViewModel viewModel = new()
            {
                ScreenId = screenInDB.ScreenId,
                CinemaId = screenInDB.CinemaId,
                ScreenNumber = screenInDB.ScreenNumber,
                Capacity = screenInDB.Capacity,
                ScreenType = screenInDB.ScreenType,
                Cinemas = _cinemaService.GetSelectListOf_Cinemas(),
                ScreenTypes = _screenService.GetSelectListOf_ScreenType(),
            };

            return View(viewModel);


            //if (id == null || _context.Screens == null)
            //{
            //    return NotFound();
            //}

            //var screen = await _context.Screens.FindAsync(id);
            //if (screen == null)
            //{
            //    return NotFound();
            //}
            //ViewData["CinemaId"] = new SelectList(_context.Cinemas, "CinemaId", "Name", screen.CinemaId);
            //return View(screen);
        }

        // POST: Screens/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ScreenFrom_ViewModel model)
        {

            if(!ModelState.IsValid)
            {
                // after that model is not vaild remember to initialize nessury field of model before return it.

                model.ScreenTypes = _screenService.GetSelectListOf_ScreenType();
                model.Cinemas = _cinemaService.GetSelectListOf_Cinemas();

                return View(model);
            }

            // Save Entity To Database using Service : var entity = _service.Edit(model)
            Screen? screenToDB = await _screenService.Edit(model);

            // check if entity null , means that BadRequest
            if (screenToDB is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));

            //if (id != screen.ScreenId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(screen);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ScreenExists(screen.ScreenId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["CinemaId"] = new SelectList(_context.Cinemas, "CinemaId", "Name", screen.CinemaId);
            //return View(screen);
        }



        // GET: Screens/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _screenService.DeleteAsync(id);

            return isDeleted ? Ok() : BadRequest("Bad Request");

        }

       
    }
}
