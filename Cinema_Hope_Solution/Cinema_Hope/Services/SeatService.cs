
namespace Cinema_Hope.Services
{
    public class SeatService : ISeatService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SeatService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Seat>> GetAllSeatsAsync()
        {
            return await _context.Seats.Include(s => s.Screen).ThenInclude(screen => screen.Cinema).ToListAsync();
        }

        public async Task<Seat?> GetByIdAsync(int id)
        {
            return  await _context.Seats
                .Include(s => s.Screen)
                .FirstOrDefaultAsync(m => m.SeatId == id);
        }

        public async Task Create(SeatFrom_ViewModel model)
        {
            // create entity model  Then Map Values here from viewModel To Entity_ToDB
            Seat screenToDB = _mapper.Map<Seat>(model);


            // save that into DB
            _context.Add(screenToDB);
            await _context.SaveChangesAsync();
        }

        public async Task<Seat?> Edit(SeatFrom_ViewModel model)
        {
            //check if Entity null in DB

            Seat? seatInDB = await _context.Seats.FindAsync(model.SeatId);

            if (seatInDB == null)
                return null;

            // map new Values From viewModel To EntityInDB
            _mapper.Map(model, seatInDB);

            // Save Changes
            var effectedRows = await _context.SaveChangesAsync();

            if (effectedRows > 0)
            {

                return seatInDB;
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

            Seat? seatInDB = await _context.Seats.FindAsync(id);

            if (seatInDB == null)
                return false;

            _context.Remove(seatInDB);

            int effectedRows = await _context.SaveChangesAsync();

            if (effectedRows > 0)
                isDeleted = true;

            return isDeleted;
        }

        
    }
}
