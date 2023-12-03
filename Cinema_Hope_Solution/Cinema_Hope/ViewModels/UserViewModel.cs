namespace Cinema_Hope.ViewModels
{
    public class UserViewModel : IdentityUser
    {
        public IEnumerable<string>? Roles { get; set; } = new List<string>();
    }
}
