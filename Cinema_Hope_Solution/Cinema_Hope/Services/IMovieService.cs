namespace Cinema_Hope.Services
{
    public interface IMovieService
    {
        Task Create(Create_MovieForm_ViewModel model);
    }
}
