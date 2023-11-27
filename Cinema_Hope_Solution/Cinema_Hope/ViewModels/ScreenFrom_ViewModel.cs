namespace Cinema_Hope.ViewModels
{
    public class ScreenFrom_ViewModel
    {
        public int ScreenId { get; set; } // Primary key

        [Display(Name = "اسم السينماء")]
        public int CinemaId { get; set; } // Foreign key


        [Display(Name = "ترتيب الشاشه التابعه للسينماء")]
        public int ScreenNumber { get; set; }


        [Display(Name = "عدد الكراسي للشاشه")]
        public int Capacity { get; set; }


        [Display(Name = "نوع الشاشه")]
        public ScreenType ScreenType { get; set; }


        public IEnumerable<SelectListItem> ScreenTypes = Enumerable.Empty<SelectListItem>(); // for View this Is SelectMenu DropDown 

        public IEnumerable<SelectListItem> Cinemas = Enumerable.Empty<SelectListItem>(); // for View this Is SelectMenu DropDown 

        // Navigation properties
        //public Cinema? Cinema { get; set; }
        //public ICollection<ShowTime> Showtimes { get; set; }
        //public ICollection<Seat> Seats { get; set; }

        //public Create_ScreenFrom_ViewModel()
        //{
        //    Showtimes = new HashSet<ShowTime>();
        //    Seats = new HashSet<Seat>();
        //}
    }
}
