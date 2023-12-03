using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_Hope.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        // Get List Of Users  With Their Role of each user
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                userViewModels.Add(new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Roles = userRoles
                });
            }

            return View(userViewModels);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var userInDB = await _userManager.FindByIdAsync(id);
            if (userInDB == null)
                return NotFound();
            var result = await _userManager.DeleteAsync(userInDB);
            if (!result.Succeeded)
                throw new Exception();
            // Good
            return Ok();
        }


    }
}
