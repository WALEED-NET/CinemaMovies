namespace Cinema_Hope.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        // Navigation property
        public ICollection<Booking> Bookings { get; set; }

        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }
    }
}
