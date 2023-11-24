namespace Cinema_Hope.Services
{
    public interface ICinemaService
    {
         IEnumerable<Cinema> GetAll();
         Cinema? GetById(int id);
         Task Create(Create_CinemaViewModel model);
    }
}
