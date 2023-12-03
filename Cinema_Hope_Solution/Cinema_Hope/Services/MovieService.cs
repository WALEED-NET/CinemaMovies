
namespace Cinema_Hope.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;
        public MovieService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
        }

        public async Task Create(Create_MovieForm_ViewModel model)
        {
            // Generate Name For Poster Nnme  of Movie when saving
            var posterNameInDB = await SavePoster(model.PosterUrl);


            // ready to save Movie in Database
            Movie movie = new()
            {
                Title = model.Title,
                Description = model.Description,
                Director = model.Director,
                Duration = model.Duration,
                GenreId = model.GenreId,
                Language = model.Language,
                PosterUrl = posterNameInDB,
                ProductionCompany = model.ProductionCompany,
                ReleaseDate = model.ReleaseDate,
                TrailerUrl = model.TrailerUrl,
                Writers = model.Writers,
                
            };

            // save into DB 
            _context.Add(movie);
            _context.SaveChanges();
        }

        public async Task<Movie?> Edit(Edit_MovieForm_ViewModel model)
        {
            // check if null

            var movieInDB = _context.Movies
                    .Include( m => m.Genre)
                    .SingleOrDefault( m => m.MovieId == model.MovieId);

            if (movieInDB == null)
                return null;

            // check Poster if has new poster to edit
            var hasNewPoster = model.PosterUrl is not null;
            var oldPoster = movieInDB.PosterUrl;

            if (hasNewPoster)
            {
                movieInDB.PosterUrl = await SavePoster(model.PosterUrl!);
            }

            // map new Values From viewModel To EntityInDB

            movieInDB.Title = model.Title;
            movieInDB.Description = model.Description;
            movieInDB.Director = model.Director;
            movieInDB.Duration = model.Duration;
            movieInDB.Status = model.Status;
            movieInDB.Writers = model.Writers;
            movieInDB.GenreId = model.GenreId;
            movieInDB.ProductionCompany = model.ProductionCompany;
            movieInDB.Language = model.Language;
            movieInDB.ReleaseDate = model.ReleaseDate;
            movieInDB.TrailerUrl = model.TrailerUrl;

            // Save Changes
            var effectedRows = _context.SaveChanges();

            //check if rows effected , then delete old poster if it replaced with new.
            if (effectedRows > 0 )
            {
                if (hasNewPoster) // means that if only user realy has changed the poster. then we need to delete old one.
                {
                    string poster = Path.Combine(_imagesPath, oldPoster);
                    File.Delete(poster);
                }
                return movieInDB;
            }
            else
            {
                // if changes does not effected, delete new poster the we try to update , and return null 
                string poster = Path.Combine(_imagesPath, movieInDB.PosterUrl);
                File.Delete(poster);

                return null;
            }
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies
                .Include( m => m.Genre)
                .AsNoTracking()
                .ToList();
        }

        public Movie? GetById(int id)
        {
            return _context.Movies
               .Include(m => m.Genre)
               .Include(m => m.Showtimes).ThenInclude(sh => sh.Screen)
               //.AsNoTracking()
               .SingleOrDefault( m => m.MovieId == id);
        }

        public bool Delete(int id)
        {
            var isDeleted = false;

            var movieInDB = _context.Movies.Find(id);

            if (movieInDB is null)
                return false;

            _context.Movies.Remove(movieInDB);
            
            var effectedRows = _context.SaveChanges();
            if (effectedRows > 0 )
            {
                // now need to delete Poster form server.
                isDeleted = true;
                string posterInserver_Path = Path.Combine(_imagesPath,movieInDB.PosterUrl);

                File.Delete(posterInserver_Path);
            }

            return isDeleted;
        }

        private async Task<string> SavePoster (IFormFile poster)
        {
            // Generate Name For Poster Nnme  of Movie when saving
            var posterNameInServer = $"{Guid.NewGuid()}{Path.GetExtension(poster.FileName)}";

            // Path for saving image
            var path = Path.Combine(_imagesPath, posterNameInServer);

            // save using stream
            using var stream = File.Create(path);
            await poster.CopyToAsync(stream);

            return posterNameInServer;
        }

        public IEnumerable<SelectListItem> GetSelectListOf_Movies()
        {
            return _context.Movies.Select(m => new SelectListItem
            {
                Text = m.Title,
                Value = m.MovieId.ToString()

            }).OrderBy(s => s.Text)
              .AsNoTracking()
              .ToList();
        }
    }
}
