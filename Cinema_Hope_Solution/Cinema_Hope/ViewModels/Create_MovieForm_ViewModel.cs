using Cinema_Hope.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema_Hope.ViewModels
{
    public class Create_MovieForm_ViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Range(0, 1000)]
        public int Duration { get; set; }

        // Validate Extention and size
        [AlowedExtensions(FileSettings.AlowedExtensions)]
        public IFormFile PosterUrl { get; set; } = default!;

        public string TrailerUrl { get; set; } = string.Empty;


        public string Language { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Writers { get; set; } = string.Empty;
        public string ProductionCompany { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "النوع" )]
        public short GenreId { get; set; }  // Foreign key

        public IEnumerable<SelectListItem> AllGeners = Enumerable.Empty<SelectListItem>(); // for View this Is SelectMenu DropDown


    }
}
