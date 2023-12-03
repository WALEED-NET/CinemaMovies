namespace Cinema_Hope.Services
{
    public interface IScreenService
    {
        Task<IEnumerable<Screen>> GetAllScreensAsync();
        Task<Screen?> GetByIdAsync(int id);
        Task Create(ScreenFrom_ViewModel model);
        Task<Screen?> Edit( ScreenFrom_ViewModel model);

        Task<bool> DeleteAsync(int id);

        IEnumerable<SelectListItem> GetSelectListOf_ScreenType();
        IEnumerable<SelectListItem> GetSelectListOf_Screens();
        IEnumerable<Seat> GetScreenSeats(int screenId);
    }
}
