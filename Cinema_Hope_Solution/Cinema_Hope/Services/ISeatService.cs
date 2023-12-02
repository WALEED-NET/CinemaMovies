namespace Cinema_Hope.Services
{
    public interface ISeatService
    {
        Task<IEnumerable<Seat>> GetAllSeatsAsync();
        Task<Seat?> GetByIdAsync(int id);
        Task Create(SeatFrom_ViewModel model);
        Task<Seat?> Edit(SeatFrom_ViewModel model);

        Task<bool> DeleteAsync(int id);

        IEnumerable<SelectListItem> GetSelectListOfSeats();
    }
}
