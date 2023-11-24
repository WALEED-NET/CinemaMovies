namespace Cinema_Hope.ViewModels
{
    public class Create_CinemaViewModel
    {
        public int CinemaId { get; set; }
        public string Name { get; set; }

        [Display(Name = "الموقع")]
        public int LocationId { get; set; } // Foreign key

        [Display(Name = "العنوان")]
        public string? Address { get; set; }

        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public IEnumerable<SelectListItem> Locations = Enumerable.Empty<SelectListItem>(); // for View this Is SelectMenu DropDown
    }
}
