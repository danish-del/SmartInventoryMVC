using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartInventory.Insfrastructure.Identity;
using SmartInventory.Insfrastructure.Service.Implementation;

namespace SmartInventory.WebApi.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JwtService _jwtService;
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser>
            signInManager, JwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string username,string email, string password)
        {
            if(string.IsNullOrWhiteSpace(username) || string.
                IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "Email or Password is Invalid");
                return View("Index");
            }
            var user = new AppUser
            {
                UserName = username,
                Email = email
            };
            var result = await _userManager.CreateAsync(user, password);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("Index");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Unauthorized();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(
                user, password, false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            var token = _jwtService.GenerateToken(user);
            return Ok(new
            {
                message = "Login Successfull!",
                token = token
            });
        }
    }
}

