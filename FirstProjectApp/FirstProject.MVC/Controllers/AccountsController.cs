using FirstProject.BL.DTOs.UserDtos;
using FirstProject.Core.Models;
using FirstProject.DAL.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.MVC.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountsController(AppDbContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    FirstName = createUserDto.FirstName,
                    LastName = createUserDto.LastName,
                    Email = createUserDto.Email,
                    UserName = createUserDto.UserName
                };
                var result = await _userManager.CreateAsync(appUser, createUserDto.Password);
                if (result.Succeeded)
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                    return View(createUserDto);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(createUserDto);
            
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid login");
                return View();
            }
            AppUser? user = await _userManager.FindByEmailAsync(loginUserDto.EmailOrUserName);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(loginUserDto.EmailOrUserName);

                if(user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login");
                    return View();
                }
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginUserDto.Password, loginUserDto.isPersistant, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid login");
            }
            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
