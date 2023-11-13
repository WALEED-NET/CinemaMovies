namespace Cinema_Hope.Services
{
    public class GenresServices : IGenresServices
    {
        private readonly ApplicationDbContext _context;

        public GenresServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<SelectListItem> GetSelectListOf_Genres()
        {
            return _context.Genres
                            .Select(genre => new SelectListItem { Value = genre.GenreId.ToString(), Text = genre.Name })
                            .OrderBy(c => c.Text)
                            .AsNoTracking()
                            .ToList();
        }
    }
}
