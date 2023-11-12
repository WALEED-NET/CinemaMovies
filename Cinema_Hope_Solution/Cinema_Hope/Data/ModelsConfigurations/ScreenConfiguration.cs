using Microsoft.EntityFrameworkCore;

namespace Cinema_Hope.Data.ModelsConfigurations
{
    public class ScreenConfiguration : IEntityTypeConfiguration<Screen>
    {
        public void Configure(EntityTypeBuilder<Screen> builder)
        {
            // Primary Key
            builder.HasKey(s => s.ScreenId);

            // Properties
            builder.Property(s => s.ScreenNumber).IsRequired();

            builder.Property(s => s.Capacity).IsRequired();

            builder.Property(s => s.ScreenType).HasConversion<string>() // because there is DataType Enum
                                               .IsRequired();

          
            // Relationships
            //3. * *Cinema - Screen relationship * *: This is a one - to - many relationship as well.One `Cinema`
            //can have many `Screens`, but each `Screen` is located in one and only one `Cinema

            //4. * *Screen - Showtime relationship * *: This is another one - to - many relationship.One `Screen`
            //can have many `Showtimes`, but each `Showtime` happens on one and only one `Screen

            //5. * *Screen - Seat relationship * *: This is a one - to - many relationship.One `Screen`
            //can have many `Seats`, but each `Seat` is located in one and only one `Screen

        }
    }
}
