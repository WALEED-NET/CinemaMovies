namespace Cinema_Hope.Services
{
    public interface IMovieServices
    {
        Task Create(Create_MovieForm_ViewModel model);
    }
}
