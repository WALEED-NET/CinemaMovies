
namespace Cinema_Hope.Models
{
    public class Screen
    {
        public int ScreenId { get; set; }
        public int CinemaId { get; set; } // Foreign key
        public int ScreenNumber { get; set; }
        public int Capacity { get; set; }
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
