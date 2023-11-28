using Microsoft.EntityFrameworkCore;

namespace Cinema_Hope.Services
{
    public class ScreenService : IScreenService
    {
        private readonly ApplicationDbContext _context;

        public ScreenService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Screen>> GetAllScreensAsync()
        {
            return await _context.Screens.Include( s => s.Cinema).ToListAsync();
        }

        public async Task<Screen?> GetByIdAsync(int id)
        {
            return await _context.Screens
               .Include(s => s.Cinema)
               .FirstOrDefaultAsync(m => m.ScreenId == id);
        }

        public async Task Create(ScreenFrom_ViewModel model)
        {
            // create entity model 
            Screen screenToDB = new()
            {
                CinemaId = model.CinemaId,
                ScreenNumber = model.ScreenNumber,
                ScreenType = model.ScreenType,
                Capacity = model.Capacity,
            };

            // save that into DB
            _context.Add(screenToDB);
            await _context.SaveChangesAsync();
        }

        public async Task<Screen?> Edit(ScreenFrom_ViewModel model)
        {
            //check if Entity null in DB

            var screenInDB = await _context.Screens.FindAsync(model.ScreenId);

            if (screenInDB == null)
                return null;

            // map new Values From viewModel To EntityInDB

            screenInDB.CinemaId = model.CinemaId;
            screenInDB.ScreenNumber = model.ScreenNumber;
            screenInDB.Capacity = model.Capacity;
            screenInDB.ScreenType = model.ScreenType;

            // Save Changes
            var effectedRows = await _context.SaveChangesAsync();

            if (effectedRows > 0)
            {

                return screenInDB;
            }
            else
            {
                // if changes does not effected,   return null 
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var isDeleted = false;

            Screen? screenInDB = await _context.Screens.FindAsync(id);

            if (screenInDB is null)
                return false;

            _context.Remove(screenInDB);

            int effectedRows = await _context.SaveChangesAsync();

            if (effectedRows > 0)
                isDeleted = true;

            return isDeleted;
        }


        public IEnumerable<SelectListItem> GetSelectListOf_ScreenType()
        {
            List<SelectListItem> screenTypes = Enum.GetValues(typeof(ScreenType))
                          .Cast<ScreenType>()
                          .Select(v => new SelectListItem
                          {
                              Text = v.ToString(),
                              Value = v.ToString() // Store the string representation of the enum
                          }).ToList();

            return screenTypes;
        }

        public IEnumerable<SelectListItem> GetSelectListOf_Screens()
        {

            return _context.Screens.Include(s => s.Cinema)
                .AsNoTracking()
                .ToList() // Fetch data into memory
                .Select(s => new SelectListItem
                {
                    Text = $"{s.Cinema.Name} screen number : {s.ScreenNumber} ",
                    Value = s.ScreenId.ToString()

                }).OrderBy(s => s.Text);

        }
    }
}
