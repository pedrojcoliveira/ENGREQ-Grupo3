using AMAPP.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace AMAPP.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient("APIClient");
        }
        public IActionResult Index()
        {
            return View();
        }
        /*public IActionResult Privacy()
        {
            return View();
        }*/
        //public IActionResult Register()
        //{
        //    return View("Register");
        //}

        //// GET: Login View
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        // POST: Login Action
        //[HttpPost]
        //public async Task<IActionResult> Login(string email, string password)
        //{
        //    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        //    {
        //        ModelState.AddModelError(string.Empty, "Username and Password are required.");
        //        return View();
        //    }
        //    try
        //    {
        //        // Cria��o do objeto para envio
        //        var loginData = new
        //        {
        //            Email = email,
        //            Password = password
        //        };

        //        // Serializar para JSON
        //        var jsonContent = JsonConvert.SerializeObject(loginData);
        //        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        //        // Enviar requisi��o POST para a API
        //        var response = await _httpClient.PostAsync("/api/Auth/login", content);

        //        // Verifica o status da resposta
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            // Adiciona mensagem de erro para tentativas inv�lidas
        //            ModelState.AddModelError(string.Empty, "Invalid login attempt. Please try again.");
        //            return View();
        //        }

        //        // Ler e desserializar os dados da resposta
        //        var json = await response.Content.ReadAsStringAsync();
        //        var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(json);

        //        // Armazenar o token na sess�o
        //        Response.Cookies.Append("jwt", loginResponse.Token, new CookieOptions
        //        {
        //            HttpOnly = true,
        //            Secure = true,
        //            SameSite = SameSiteMode.Strict
        //        });

        //        // Redireciona para ProductController > List ap�s login bem-sucedido
        //        return RedirectToAction("List", "Products");
        //    }
        //    catch(Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again.");
        //        return View();
        //    }
        //}

        // M�todo para erros
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}