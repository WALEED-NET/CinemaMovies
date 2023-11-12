namespace Cinema_Hope.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        [Required]
        [StringLength(255)]
        public  string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }

    }
}
