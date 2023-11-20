namespace Cinema_Hope.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();

        Movie? GetById(int id);

        Task Create(Create_MovieForm_ViewModel model);

        Task<Movie?> Edit(Edit_MovieForm_ViewModel model);

        bool Delete(int id);
    }
}
