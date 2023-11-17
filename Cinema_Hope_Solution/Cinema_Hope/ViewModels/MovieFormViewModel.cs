namespace Cinema_Hope.ViewModels
{
    public class MovieFormViewModel
    {
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        [Range(0, 1000)]
        public int Duration { get; set; }

       

        public string? TrailerUrl { get; set; } = string.Empty;


        public string? Language { get; set; } = string.Empty;
        public string? Director { get; set; } = string.Empty;
        public string? Writers { get; set; } = string.Empty;
        public string? ProductionCompany { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "النوع")]
        public int GenreId { get; set; }  // Foreign key

        public IEnumerable<SelectListItem> AllGeners = Enumerable.Empty<SelectListItem>(); // for View this Is SelectMenu DropDown

    }
}
