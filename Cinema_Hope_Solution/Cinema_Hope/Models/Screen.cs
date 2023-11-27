
namespace Cinema_Hope.Models
{
    public class Screen
    {
        public int ScreenId { get; set; }


        [Display(Name = "اسم السينماء")]
        public int CinemaId { get; set; } // Foreign key


        [Display(Name = "ترتيب الشاشه التابعه للسينماء")]
        public int ScreenNumber { get; set; }


        [Display(Name = "عدد الكراسي للشاشه")]
        public int Capacity { get; set; }


        [Display(Name = "نوع الشاشه")]
        public ScreenType ScreenType { get; set; }

        // Navigation properties
        public Cinema? Cinema { get; set; }
        public ICollection<ShowTime> Showtimes { get; set; }
        public ICollection<Seat> Seats { get; set; }

        public Screen()
        {
            Showtimes = new HashSet<ShowTime>();
            Seats = new HashSet<Seat>();
        }
    }
}
