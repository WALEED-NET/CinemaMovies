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
            var posterNameInDB = $"{Guid.NewGuid()}{Path.GetExtension(model.PosterUrl.FileName)}";

            // Path for saving image
            var path = Path.Combine(_imagesPath, posterNameInDB);

            // save using stream
            using var stream = File.Create(path);
            await model.PosterUrl.CopyToAsync(stream);


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
    }
}
