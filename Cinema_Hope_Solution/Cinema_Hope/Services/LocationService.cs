namespace Cinema_Hope.Services
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _context;

        public LocationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectListOf_Locations()
        {
            return _context.Locations.
                Select(location => new SelectListItem { Value = location.LocationId.ToString(), Text = location.City })
                .OrderBy( l => l.Text )
                .AsNoTracking()
                .ToList();
        }
    }
}
