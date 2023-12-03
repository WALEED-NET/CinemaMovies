
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefualtConnection")
            ?? throw new InvalidOperationException("No Connection String Was Found");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString)); // Register DbContext 

builder.Services.AddScoped<IGenresService, GenresService>();         // inject IGenresServices.
builder.Services.AddScoped<IMovieService, MovieService>();          // inject IMovieServices.
builder.Services.AddScoped<ILocationService, LocationService>();  // inject ILocationServices.
builder.Services.AddScoped<ICinemaService, CinemaService>();     // inject ICinemaServices.
builder.Services.AddScoped<IScreenService, ScreenService>();
builder.Services.AddScoped<IShowTimeService, ShowTimeService>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddAutoMapper(typeof(Program));    // add AutoMapper.

builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation(); // I Add this For Speed The  changes in your views immediately without rebuilding the project.

builder.Services.AddControllers().AddJsonOptions(   options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();