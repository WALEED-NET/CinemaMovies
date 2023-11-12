namespace Cinema_Hope.Models
{
    public class Seat
    {

        public Seat()
        {
            Bookings = new HashSet<Booking>();
        }

        public int SeatId { get; set; }
        public int ScreenId { get; set; } // Foreign key
        public short RowNumber { get; set; }
        public short SeatNumber { get; set; }
        public bool IsBookedUp { get; set; } = false;

        // Navigation property
        public Screen? Screen { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}
