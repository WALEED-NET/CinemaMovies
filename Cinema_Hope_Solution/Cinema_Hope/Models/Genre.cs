namespace Cinema_Hope.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } = default!;

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

    }
}
