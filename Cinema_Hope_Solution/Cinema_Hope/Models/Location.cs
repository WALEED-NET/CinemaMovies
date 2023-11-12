namespace Cinema_Hope.Models
{
    public class Location
    {
        public Location()
        {
            Cinemas = new HashSet<Cinema>();
        }

        public int LocationId { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }

        // Navigation property
        public ICollection<Cinema> Cinemas { get; set; }
    }
}
