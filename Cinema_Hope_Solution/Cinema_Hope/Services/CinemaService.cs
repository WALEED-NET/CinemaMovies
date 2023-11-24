namespace Cinema_Hope.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly ApplicationDbContext _context;

        public CinemaService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Cinema> GetAll()
        {
            return _context.Cinemas
                .Include(c => c.Location)
                .AsNoTracking()
                .ToList();
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

    }
}
