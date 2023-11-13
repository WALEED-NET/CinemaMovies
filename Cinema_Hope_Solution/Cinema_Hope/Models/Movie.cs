using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema_Hope.Models
{
    public class Movie
    {
        public Movie()
        {
            Showtimes = new HashSet<ShowTime>();
        }

        public int MovieId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        [Range(0,1000)]
        public int Duration { get; set; }

        public string? PosterUrl { get; set; }
        public string? TrailerUrl { get; set; }

        [Range(0, 5)]
        public double Rating { get; set; }

        public string? Language { get; set; }
        public string? Director { get; set; }
        public string? Writers { get; set; }
        public string? ProductionCompany { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Status { get; set; }


        [Display(Name = "Genre"), Required]
        public int GenreId { get; set; }

        // Navigation property

        [ForeignKey(nameof(GenreId))]
        public Genre? Genre { get; set; }

        public ICollection<ShowTime> Showtimes { get; set; }
    }
}
