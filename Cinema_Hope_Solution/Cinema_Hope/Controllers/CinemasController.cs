namespace Cinema_Hope.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILocationService _locationService;
        private readonly ICinemaService _cinemaService;


        public CinemasController(ApplicationDbContext context, ILocationService locationService, ICinemaService cinemaService)
        {
            _context = context;
            _locationService = locationService;
            _cinemaService = cinemaService;
        }

        // GET: Cinemas
        public async Task<IActionResult> Index()
        {
            var cinemas = _cinemaService.GetAll();
            return View(cinemas);
            //var applicationDbContext = _context.Cinemas.Include(c => c.Location);
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cinemas == null)
            {
                return NotFound();
            }

            //var cinema = await _context.Cinemas
            //    .Include(c => c.Location)
            //    .FirstOrDefaultAsync(m => m.CinemaId == id);

            var cinema = _cinemaService.GetById( (int) id);

            if (cinema == null)
            {
                return NotFound();
            }

            return View(cinema);
        }


        // GET: Cinemas/Create
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
                model.Locations = _locationService.GetSelectListOf_Locations();
                return View(model);
            }

            // let cinema service do create and save to database
            await _cinemaService.Create(model);
           
            return RedirectToAction(nameof(Index));
        }



        // GET: Cinemas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cinemas == null)
            {
                return NotFound();
            }

            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId", cinema.LocationId);
            return View(cinema);
        }

        // POST: Cinemas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CinemaId,Name,LocationId,Address,PostalCode,Phone,Email")] Cinema cinema)
        {
            if (id != cinema.CinemaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinemaExists(cinema.CinemaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId", cinema.LocationId);
            return View(cinema);
        }

        // GET: Cinemas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cinemas == null)
            {
                return NotFound();
            }

            var cinema = await _context.Cinemas
                .Include(c => c.Location)
                .FirstOrDefaultAsync(m => m.CinemaId == id);
            if (cinema == null)
            {
                return NotFound();
            }

            return View(cinema);
        }

        // POST: Cinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cinemas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cinemas'  is null.");
            }
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema != null)
            {
                _context.Cinemas.Remove(cinema);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinemaExists(int id)
        {
          return (_context.Cinemas?.Any(e => e.CinemaId == id)).GetValueOrDefault();
        }
    }
}
