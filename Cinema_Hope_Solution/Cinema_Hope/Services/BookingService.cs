
namespace Cinema_Hope.Services
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookingService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings.Include(b => b.Customer).Include(b => b.Seat).Include(b => b.Showtime).ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            return  await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Seat)
                .Include(b => b.Showtime)
                .SingleOrDefaultAsync(m => m.BookingId == id);
        }


        public async Task Create(Booking_ViewModel model)
        {
            // create entity model  Then Map Values here from viewModel To Entity_ToDB
            Booking bookingToDB = _mapper.Map<Booking>(model);

            // save that into DB

            _context.Add(bookingToDB);
            await _context.SaveChangesAsync();
        }

        public async Task<Booking?> Edit(Booking_ViewModel model)
        {
            //check if Entity null in DB

            Booking? bookingInDB = await _context.Bookings.FindAsync(model.BookingId);

            if (bookingInDB == null)
                return null;

            // map new Values From viewModel To EntityInDB
            _mapper.Map(model, bookingInDB);

            // Save Changes
            var effectedRows = await _context.SaveChangesAsync();

            if (effectedRows > 0)
            {

                return bookingInDB;
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

            Booking? bookingInDB = await _context.Bookings.FindAsync(id);

            if (bookingInDB is null)
                return false;

            _context.Remove(bookingInDB);

            int effectedRows = await _context.SaveChangesAsync();

            if (effectedRows > 0)
                isDeleted = true;

            return isDeleted;
        }

        public IEnumerable<SelectListItem> GetSelectListOf_BookingStatus()
        {
            return Enum.GetValues(typeof(BookingStatus))
                   .Cast<BookingStatus>()
                   .Select(bookinState => new SelectListItem
                   {
                       Text = bookinState.ToString(),
                       Value = bookinState.ToString() // Store the string representation of the enum
                   }).ToList();
        }

        public IEnumerable<SelectListItem> GetSelectListOf_Customers()
        {
            return _context.Customers.Select( cu => new SelectListItem { Value = cu.CustomerId.ToString() , Text =  cu.Name } ).ToList();
        }

    }
}
