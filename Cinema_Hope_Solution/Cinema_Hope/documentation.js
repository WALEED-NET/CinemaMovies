//Sure, I can guide you on how to create the models for your cinema website using ASP.NET Core 7
//with Entity Framework Core in a Code First approach.Here's a basic example of how you can define your models:

```csharp
public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public string Genre { get; set; }
    public string PosterUrl { get; set; }
    public string TrailerUrl { get; set; }
    public double Rating { get; set; }
    public string Language { get; set; }
    public string Director { get; set; }
    public string Writers { get; set; }
    public string Stars { get; set; }
    public string ProductionCompany { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Status { get; set; }

    // Navigation property
    public ICollection<Showtime> Showtimes { get; set; }
}

public class Location
{
    public int LocationId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }

    // Navigation property
    public ICollection<Cinema> Cinemas { get; set; }
}

public class Cinema
{
    public int CinemaId { get; set; }
    public string Name { get; set; }
    public int LocationId { get; set; } // Foreign key
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    // Navigation properties
    public Location Location { get; set; }
    public ICollection<Screen> Screens { get; set; }
}

// Similar classes can be created for Screen, Showtime, Seat, Customer, and Booking.
```

//In the Code First approach, you define your models first, and then Entity Framework Core will create the database and tables based on these models. 

//To avoid null reference exceptions, make sure to initialize your collections in the constructor of your classes:

```csharp
public Movie()
{
    Showtimes = new HashSet<Showtime>();
}

public Location()
{
    Cinemas = new HashSet<Cinema>();
}

public Cinema()
{
    Screens = new HashSet<Screen>();
}
```

//Also, remember to add the necessary using statements at the top of your file:

```csharp
using System;
using System.Collections.Generic;
```

//This is a basic example and might need adjustments based on your exact requirements. For example, you might want to add more properties, change data types, or add more constraints. 

//Remember to add the necessary DbSet properties to your DbContext class:

```csharp
public DbSet<Movie> Movies { get; set; }
public DbSet<Location> Locations { get; set; }
public DbSet<Cinema> Cinemas { get; set; }
// Add similar DbSet properties for other classes
```

//I hope this helps! If you have any more questions or need further clarification, feel free to ask. 😊


//=======

//بالطبع، هنا هي الطبقات المتبقية:

```csharp
public class Screen
{
    public int ScreenId { get; set; }
    public int CinemaId { get; set; } // Foreign key
    public string ScreenNumber { get; set; }
    public int Capacity { get; set; }
    public string ScreenType { get; set; }

    // Navigation properties
    public Cinema Cinema { get; set; }
    public ICollection<Showtime> Showtimes { get; set; }
    public ICollection<Seat> Seats { get; set; }

    public Screen()
    {
        Showtimes = new HashSet<Showtime>();
        Seats = new HashSet<Seat>();
    }
}

public class Showtime
{
    public int ShowtimeId { get; set; }
    public int MovieId { get; set; } // Foreign key
    public int ScreenId { get; set; } // Foreign key
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal TicketPrice { get; set; }
    public string Status { get; set; }

    // Navigation properties
    public Movie Movie { get; set; }
    public Screen Screen { get; set; }
    public ICollection<Booking> Bookings { get; set; }

    public Showtime()
    {
        Bookings = new HashSet<Booking>();
    }
}

public class Seat
{
    public int SeatId { get; set; }
    public int ScreenId { get; set; } // Foreign key
    public string RowNumber { get; set; }
    public string SeatNumber { get; set; }
    public string SeatStatus { get; set; }

    // Navigation property
    public Screen Screen { get; set; }
}

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }

    // Navigation property
    public ICollection<Booking> Bookings { get; set; }

    public Customer()
    {
        Bookings = new HashSet<Booking>();
    }
}

public class Booking
{
    public int BookingId { get; set; }
    public int ShowtimeId { get; set; } // Foreign key
    public int SeatId { get; set; } // Foreign key
    public int CustomerId { get; set; } // Foreign key
    public DateTime BookingDate { get; set; }
    public string Status { get; set; }

    // Navigation properties
    public Showtime Showtime { get; set; }
    public Seat Seat { get; set; }
    public Customer Customer { get; set; }
}
```

//وأخيراً، تذكر أن تضيف الخصائص DbSet اللازمة إلى فئة DbContext الخاصة بك:

```csharp
public DbSet<Movie> Movies { get; set; }
public DbSet<Location> Locations { get; set; }
public DbSet<Cinema> Cinemas { get; set; }
public DbSet<Screen> Screens { get; set; }
public DbSet<Showtime> Showtimes { get; set; }
public DbSet<Seat> Seats { get; set; }
public DbSet<Customer> Customers { get; set; }
public DbSet<Booking> Bookings { get; set; }
```

//هذا هو الإعداد الأساسي للطبقات في ASP.NET Core باستخدام Entity Framework Core في نهج Code First.
//قد تحتاج إلى تعديل هذه الطبقات بناءً على متطلباتك الخاصة.إذا كانت لديك أي أسئلة أخرى أو تحتاج
//إلى مزيد من التوضيح، فلا تتردد في السؤال. 😊

