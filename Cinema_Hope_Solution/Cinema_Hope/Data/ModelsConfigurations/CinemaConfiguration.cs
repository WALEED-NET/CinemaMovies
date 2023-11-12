namespace Cinema_Hope.Data.ModelsConfigurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            // Primary Key
            builder.HasKey(c => c.CinemaId);

            // Properties
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100); 

            builder.Property(c => c.Address)
                .HasMaxLength(200); 

            builder.Property(c => c.PostalCode)
                .HasMaxLength(10); 

            builder.Property(c => c.Phone)
                .HasMaxLength(20); 

            builder.Property(c => c.Email)
                .HasMaxLength(100);

            // Relationships
            //2. * *Location - Cinema relationship * *: This is also a one - to - many relationship.One `Location`
            //can have many `Cinemas`, but each `Cinema` is located at one and only one `Location

            //3. * *Cinema - Screen relationship * *: This is a one - to - many relationship as well.One `Cinema`
            //can have many `Screens`, but each `Screen` is located in one and only one `Cinema

        }
    }
}
