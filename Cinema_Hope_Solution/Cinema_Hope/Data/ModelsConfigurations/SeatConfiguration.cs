namespace Cinema_Hope.Data.ModelsConfigurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            // Primary Key
            builder.HasKey(s => s.SeatId);

            // Properties
            builder.Property(s => s.RowNumber).IsRequired();
            builder.Property(s => s.SeatNumber).IsRequired();
            builder.Property(s => s.IsBookedUp).IsRequired();

            // Relationships
            //5. * *Screen - Seat relationship * *: This is a one - to - many relationship.One `Screen`
            //can have many `Seats`, but each `Seat` is located in one and only one `Screen

            // 7. * *Seat - Booking relationship * *: This is a one - to - one relationship.Each `Seat`
            // can have one `Booking`, and each `Booking` is associated with one and only one `Seat


        }
    }
}
