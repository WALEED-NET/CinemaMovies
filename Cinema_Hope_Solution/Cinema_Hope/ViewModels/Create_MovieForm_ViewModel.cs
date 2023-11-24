namespace Cinema_Hope.ViewModels
{
    public class Create_MovieForm_ViewModel : MovieFormViewModel
    {

        [AlowedExtensions(FileSettings.AlowedExtensions) , MaxFileSize(FileSettings.MaxFileSizeInBytes) ]
        public IFormFile PosterUrl { get; set; } = default!;

    }
}
