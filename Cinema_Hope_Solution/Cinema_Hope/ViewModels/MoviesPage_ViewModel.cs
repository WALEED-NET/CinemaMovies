namespace Cinema_Hope.ViewModels
{
    public class MoviesPage_ViewModel
    {
        public IEnumerable<Movie>? Movies { get; set; }
        public IEnumerable<SelectListItem>? Genres { get; set; }
        public IEnumerable<SelectListItem>? Cinemas { get; set; }
        public IEnumerable<SelectListItem>? Screens { get; set; }

        
    }
}
