namespace Cinema_Hope.Data.ModelsConfigurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            // Primary Key
            builder.HasKey(movie => movie.MovieId);

            // Properties => Columns

            builder.Property(m => m.Title).IsRequired()
                                          .HasMaxLength(100);

            builder.Property(m => m.Description).HasMaxLength(1000);


            builder.Property(m => m.Duration); // nothing

           

            builder.Property(m => m.PosterUrl).HasMaxLength(500);
           //.IsRequired()


            builder.Property(m => m.TrailerUrl) .HasMaxLength(500);
                //.IsRequired()

            builder.Property(m => m.Rating).HasMaxLength(500);

            builder.Property(m => m.Language).HasMaxLength(50);
                //.IsRequired()

            builder.Property(m => m.Director) .HasMaxLength(100);
             //.IsRequired()

            builder.Property(m => m.Writers).HasMaxLength(200);
              //.IsRequired()

            builder.Property(m => m.ProductionCompany).HasMaxLength(100);
               //.IsRequired()

            builder.Property(m => m.ReleaseDate).IsRequired();

            builder.Property(m => m.Status).HasMaxLength(20);
            //.IsRequired()


            // RelationShips
            //1. * *Movie - Showtime relationship * *: This is a one - to - many relationship.One `Movie`
            //can have many `Showtimes`, but each `Showtime` is associated with one and only one `Movie`.


        }
    }
}
