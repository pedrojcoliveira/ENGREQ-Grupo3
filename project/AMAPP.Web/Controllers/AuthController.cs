using AMAPP.Web.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace AMAPP.Web.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly HttpClient _httpClient;

        public AuthController(ILogger<AuthController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient("APIClient");
        }

        // GET: Login View
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login Action
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError(string.Empty, "Email and Password are required.");
                return View();
            }

            try
            {
                var loginData = new
                {
                    Email = email,
                    Password = password
                };

                var jsonContent = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Auth/login", content);

                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt. Please try again.");
                    return View();
                }

                var json = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(json);

                Response.Cookies.Append("jwt", loginResponse.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict
                });

                return RedirectToAction("List", "Products");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login process.");
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again.");
                return View();
            }
        }

        // GET: Register View
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register Action
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var jsonContent = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Auth/register", content);

                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                    return View(model);
                }

                return RedirectToAction("Login", "Auth");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration process.");
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again.");
                return View(model);
            }
        }

        // Handle Errors
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet("error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
