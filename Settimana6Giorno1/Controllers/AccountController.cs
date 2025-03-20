using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Settimana6Giorno1.Models;
using Settimana6Giorno1.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Settimana6Giorno1.Data;
using Microsoft.EntityFrameworkCore;



namespace Settimana6Giorno1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly StudentDbContext _studentDbContext;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            StudentDbContext studentDbContext
        )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            _studentDbContext = studentDbContext;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
   
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user == null)
            {
                return View();
            }

      
            var signInResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, true, false);

   
            var roles = await _signInManager.UserManager.GetRolesAsync(user);

      
            List<Claim> claims = new List<Claim>();

        
            claims.Add(new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"));

        
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

         
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

         
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

           
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            if (!signInResult.Succeeded)
            {
                return View();
            }

            
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        { 
            var newUser = new ApplicationUser()
            {
                Email = registerViewModel.Email, 
                UserName = registerViewModel.Email, 
                FirstName = registerViewModel.FirstName, 
                LastName = registerViewModel.LastName,
                BirthDate = registerViewModel.BirthDate, 
            };

            var result = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (!result.Succeeded)
            {
                return View();
            }

          
            var user = await _userManager.FindByEmailAsync(newUser.Email);

  
            await _userManager.AddToRoleAsync(user, "Admin");
            //var text =await _studentDbContext.ApplicationUsers.Include(a => a.ApplicationUserRole).ThenInclude(ap => ap.Role).ToListAsync();

      
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

      
        public IActionResult Index()
        {
            return View();
        }
    }
}
    
