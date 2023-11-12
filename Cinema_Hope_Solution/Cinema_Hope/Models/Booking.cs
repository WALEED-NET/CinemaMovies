namespace Cinema_Hope.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int ShowtimeId { get; set; } // Foreign key
        public int SeatId { get; set; } // Foreign key
        public int CustomerId { get; set; } // Foreign key
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; } 

        // Navigation properties
        public ShowTime? Showtime { get; set; }
        public Seat? Seat { get; set; }
        public Customer? Customer { get; set; }
    }
}
