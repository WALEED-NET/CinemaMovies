namespace Cinema_Hope.Data.ModelsConfigurations
{
    public class ShowTimeConfiguration : IEntityTypeConfiguration<ShowTime>
    {
        public void Configure(EntityTypeBuilder<ShowTime> builder)
        {
            //key
            builder.HasKey(s => s.ShowTimeId);

            // Properties => Columns
            builder.Property(e => e.MovieId).IsRequired();
            builder.Property(e => e.ScreenId).IsRequired();
            builder.Property(e => e.StartTime).IsRequired();
            builder.Property(e => e.EndTime).IsRequired();
            builder.Property(e => e.TicketPrice).IsRequired();
            builder.Property(e => e.Status);
            //.IsRequired();


            // RelationShips
            //1. * *Movie - Showtime relationship * *: This is a one - to - many relationship.One `Movie` can have many
            //`Showtimes`, but each `Showtime` is associated with one and only one `Movie`.

            //4. * *Screen - Showtime relationship * *: This is another one - to - many relationship.One `Screen` can have
            //many `Showtimes`, but each `Showtime` happens on one and only one `Screen



        }
    }
}
