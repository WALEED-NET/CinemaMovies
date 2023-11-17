namespace Cinema_Hope.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();

        Movie? GetById(int id);

        Task Create(Create_MovieForm_ViewModel model);
    }
}
