namespace Cinema_Hope.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking?> GetByIdAsync(int id);
        Task Create(Booking_ViewModel model);
        Task<Booking?> Edit(Booking_ViewModel model);

        Task<bool> DeleteAsync(int id);

        IEnumerable<SelectListItem> GetSelectListOf_BookingStatus();
        IEnumerable<SelectListItem> GetSelectListOf_Customers();
    }
}
