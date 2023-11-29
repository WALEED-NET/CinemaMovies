namespace Cinema_Hope.Services
{
    public interface IShowTimeService
    {
        Task<IEnumerable<ShowTime>> GetAllShowTimesAsync();
        Task<ShowTime?> GetByIdAsync(int id);
        Task Create(ShowTime_ViewModel model);
        Task<ShowTime?> Edit(ShowTime_ViewModel model);

        Task<bool> DeleteAsync(int id);

        IEnumerable<SelectListItem> GetSelectListOf_ShowTimeStatus();
        IEnumerable<SelectListItem> GetSelectListOf_ShowTimes();
    }
}
