namespace Cinema_Hope.ViewModels
{
    public class Edit_MovieForm_ViewModel : MovieFormViewModel
    {
        public int MovieId { get; set; }

        public required string? CurrentPoster { get; set; }

        public string? Status { get; set; }

        [AlowedExtensions(FileSettings.AlowedExtensions), MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? PosterUrl { get; set; } 
    }
}
