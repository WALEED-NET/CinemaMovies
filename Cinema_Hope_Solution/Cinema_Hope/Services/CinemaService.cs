namespace Cinema_Hope.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly ApplicationDbContext _context;

        public CinemaService(ApplicationDbContext context)
        {
            _context = context;
        }
        public  async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            return await _context.Cinemas
                .Include(c => c.Location)
                .AsNoTracking()
                .ToListAsync();
        }

        public Cinema? GetById(int id)
        {
            return _context.Cinemas.Include(c => c.Location)
                                   .SingleOrDefault(c => c.CinemaId == id);
        }

        public async Task Create( Create_CinemaViewModel model )
        {
            // create cinema model 
            Cinema cinemaToDB = new()
            {
                Name = model.Name,
                Address = model.Address,
                CinemaId = model.CinemaId,
                Email = model.Email,
                LocationId = model.LocationId,
                Phone = model.Phone,
                PostalCode = model.PostalCode, 
            };

            // save that into DB
            _context.Add(cinemaToDB);
            await _context.SaveChangesAsync();
            
        }

        public async Task<Cinema?> Edit(Edit_Cinema_ViewModel model)
        {
            //check if Entity null in DB

            var cinemaInDB = _context.Cinemas.Include(c => c.Location)
                                         .SingleOrDefault(c => c.CinemaId == model.CinemaId);

            if (cinemaInDB == null)
                return null;

            // map new Values From viewModel To EntityInDB

            cinemaInDB.Name = model.Name;
            cinemaInDB.Address = model.Address;
            cinemaInDB.Email = model.Email;
            cinemaInDB.LocationId = model.LocationId;
            cinemaInDB.Phone = model.Phone;
            cinemaInDB.PostalCode = model.PostalCode;

            // Save Changes
            var effectedRows = await _context.SaveChangesAsync();

            //check if rows effected , then delete old poster if it replaced with new.
            if (effectedRows > 0)
            {
              
                return cinemaInDB;
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

            Cinema? cinemaInDB = await _context.Cinemas.Include(c => c.Screens).SingleOrDefaultAsync(c => c.CinemaId == id);

            if (cinemaInDB is null)
                return false;

            _context.Cinemas.Remove(cinemaInDB);

            int effectedRows = await _context.SaveChangesAsync();

            if (effectedRows > 0)
                isDeleted = true;

            return isDeleted;
        }
    }
}
