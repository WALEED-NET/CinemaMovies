namespace Cinema_Hope.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options)
    {
        
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Screen> Screens { get; set; }
    public DbSet<ShowTime> ShowTimes { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);



        // Call Models Configurations here :
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieConfiguration).Assembly);


        //------- All Tables RelationShips Here: -----------------
        ///<summary>
        /// here are the relationships between your tables:
        /// 
        ///1. * *Movie - Showtime relationship * *: This is a one - to - many relationship.One `Movie` can have many `Showtimes`, but each `Showtime` is associated with one and only one `Movie`.
        ///
        ///2. * *Location - Cinema relationship * *: This is also a one - to - many relationship.One `Location` can have many `Cinemas`, but each `Cinema` is located at one and only one `Location
        ///
        ///3. * *Cinema - Screen relationship * *: This is a one - to - many relationship as well.One `Cinema` can have many `Screens`, but each `Screen` is located in one and only one `Cinema
        ///
        ///4. * *Screen - Showtime relationship * *: This is another one - to - many relationship.One `Screen` can have many `Showtimes`, but each `Showtime` happens on one and only one `Screen
        ///
        ///5. * *Screen - Seat relationship * *: This is a one - to - many relationship.One `Screen` can have many `Seats`, but each `Seat` is located in one and only one `Screen
        ///
        ///6. * *Showtime - Booking relationship * *: This is a one - to - many relationship.One `Showtime` can have many `Bookings`, but each `Booking` is associated with one and only one `Showtime
        ///
        /// 7. * *Seat - Booking relationship * *: This is a one - to - one relationship.Each `Seat` can have one `Booking`, and each `Booking` is associated with one and only one `Seat
        /// 
        /// 8. * *Customer - Booking relationship * *: This is a one - to - many relationship.One `Customer` can have many `Bookings`, but each `Booking` is made by one and only one `Customer`.
        ///</summary>



        // Movie-Showtime relationship ( One => Many )
        modelBuilder.Entity<Movie>().HasMany(m => m.Showtimes) // Icolletion of Showtimes inside Movie Model
                                    .WithOne(s => s.Movie) // means ShowTime has One Movie
                                    .HasForeignKey( s => s.MovieId) // Foreignkey inside Child That will Reference Parent Primary 
                                    .OnDelete(DeleteBehavior.Cascade);


        // Location-Cinema relationship ( One => Many )
        modelBuilder.Entity<Location>().HasMany(l => l.Cinemas)
                                       .WithOne(cinema => cinema.Location)
                                       .HasForeignKey(cinema => cinema.LocationId)
                                       .OnDelete(DeleteBehavior.SetNull);



        // Cinema-Screen relationship ( One => Many )
        modelBuilder.Entity<Cinema>().HasMany(cinema => cinema.Screens)
                                     .WithOne(screen => screen.Cinema)
                                     .HasForeignKey(screen => screen.CinemaId)
                                     .OnDelete(DeleteBehavior.Cascade);

        // Screen-Showtime relationship ( One => Many) One Screen can have many Showtimes, but each Showtime happens on one and only one Screen.
        modelBuilder.Entity<Screen>().HasMany(s => s.Showtimes)
                                     .WithOne(st => st.Screen)
                                     .HasForeignKey(st => st.ScreenId)
                                     .OnDelete(DeleteBehavior.Restrict);

        // Screen-Seat relationship ( One => Many)
        modelBuilder.Entity<Screen>().HasMany(one_Screen => one_Screen.Seats)
                                     .WithOne(seat => seat.Screen)
                                     .HasForeignKey(seat => seat.ScreenId)
                                     .OnDelete(DeleteBehavior.Cascade);

        // ShowTime-Booking relationship ( One => Many )
        modelBuilder.Entity<ShowTime>().HasMany(st => st.Bookings)
                                       .WithOne(booking => booking.Showtime)
                                       .HasForeignKey(b => b.ShowtimeId)
                                       .OnDelete(DeleteBehavior.Cascade);

        //Seat - Booking relationship ( One => Many )
        modelBuilder.Entity<Seat>().HasMany(seat => seat.Bookings)
                                   .WithOne(booking => booking.Seat)
                                   .HasForeignKey(booking => booking.SeatId)
                                   .OnDelete(DeleteBehavior.Restrict);


        // Customer and Booking relationship ( One => Many )
        modelBuilder.Entity<Customer>().HasMany(u => u.Bookings)
                                       .WithOne(b => b.Customer)
                                       .HasForeignKey(b => b.CustomerId);
    }
}
