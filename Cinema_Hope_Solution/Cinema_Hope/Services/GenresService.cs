namespace Cinema_Hope.Services
{
    public class GenresService : IGenresService
    {
        private readonly ApplicationDbContext _context;

        public GenresService(ApplicationDbContext context)
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
