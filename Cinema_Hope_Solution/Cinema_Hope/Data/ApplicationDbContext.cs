namespace Cinema_Hope.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options)
    {
        
    }
}
