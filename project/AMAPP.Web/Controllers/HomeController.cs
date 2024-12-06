using AMAPP.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
namespace AMAPP.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient("AMAPPClient");
        }
        public IActionResult Index()
        {
            return View("Login");
        }
        /*public IActionResult Privacy()
        {
            return View();
        }*/
        public IActionResult Register()
        {
            return View("Register");
        }

        // GET: Login View
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login Action
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError(string.Empty, "Username and Password are required.");
                return View();
            }

            try
            {
                // Criação do objeto para envio
                var loginData = new
                {
                    Email = email,
                    Password = password
                };

                // Serializar para JSON
                var jsonContent = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Enviar requisição POST para a API
                var response = await _httpClient.PostAsync("/api/Auth/login", content);

                // Verifica o status da resposta
                if (response.IsSuccessStatusCode)
                {
                    // Redireciona para ProductController > List após login bem-sucedido
                    return RedirectToAction("List", "Product");
                }

                // Adiciona mensagem de erro para tentativas inválidas
                ModelState.AddModelError(string.Empty, "Invalid login attempt. Please try again.");
                return View();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again.");
                return View();
            }
        }

        // Método para erros
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}