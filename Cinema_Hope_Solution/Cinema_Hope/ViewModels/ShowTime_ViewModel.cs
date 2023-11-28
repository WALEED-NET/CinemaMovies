namespace Cinema_Hope.ViewModels
{
    public class ShowTime_ViewModel
    {
        public int ShowTimeId { get; set; }

        [Display(Name = "اسم الفلم")]
        public int MovieId { get; set; } // Foreign key

        [Display(Name = "الشاشه")]
        public int ScreenId { get; set; } // Foreign key

        [Display(Name = "وقت البدايه")]
        public DateTime StartTime { get; set; }

        [Display(Name = "وقت النهايه")]
        public DateTime EndTime { get; set; }

        [Display(Name = "سعر التذكره")]
        public decimal TicketPrice { get; set; }

        [Display(Name = "حاله العرض")]
        public string? Status { get; set; }

        public IEnumerable<SelectListItem> SelectListOfMovies = Enumerable.Empty<SelectListItem>(); // for View this Is SelectMenu DropDown
        public IEnumerable<SelectListItem> SelectListOfScreens = Enumerable.Empty<SelectListItem>(); // for View this Is SelectMenu DropDown
        public IEnumerable<SelectListItem> SelectListOf_ShowTimeStatus = Enumerable.Empty<SelectListItem>(); // for View this Is SelectMenu DropDown

    }
}
