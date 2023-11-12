namespace Cinema_Hope.Models
{
    public class ShowTime
    {
        public int ShowTimeId { get; set; }
        public int MovieId { get; set; } // Foreign key
        public int ScreenId { get; set; } // Foreign key
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TicketPrice { get; set; }
        public string? Status { get; set; }



        // Navigation properties
        public Movie? Movie { get; set; }
        public Screen? Screen { get; set; }
        public ICollection<Booking> Bookings { get; set; }

        public ShowTime()
        {
            Bookings = new HashSet<Booking>();
        }
    }
}
