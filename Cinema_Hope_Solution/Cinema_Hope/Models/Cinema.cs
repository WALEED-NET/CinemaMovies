namespace Cinema_Hope.Models
{
    public class Cinema
    {

        public Cinema()
        {
            Screens = new HashSet<Screen>();
        }

        public int CinemaId { get; set; }
        public required string Name { get; set; }
        public int LocationId { get; set; } // Foreign key
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        // Navigation properties
        public Location? Location { get; set; }
        public ICollection<Screen> Screens { get; set; }
    }
}
