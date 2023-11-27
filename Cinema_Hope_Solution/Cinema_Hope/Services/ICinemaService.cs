namespace Cinema_Hope.Services
{
    public interface ICinemaService
    {
         Task<IEnumerable<Cinema>> GetAllAsync();

         IEnumerable<SelectListItem> GetSelectListOf_Cinemas(); // for View used

         Cinema? GetById(int id);

         Task Create(Create_CinemaViewModel model);

         Task<Cinema?> Edit(Edit_Cinema_ViewModel model);

         Task<bool> DeleteAsync(int id);
    }
}
