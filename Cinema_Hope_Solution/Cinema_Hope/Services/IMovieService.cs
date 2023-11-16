namespace Cinema_Hope.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
        Task Create(Create_MovieForm_ViewModel model);
    }
}
