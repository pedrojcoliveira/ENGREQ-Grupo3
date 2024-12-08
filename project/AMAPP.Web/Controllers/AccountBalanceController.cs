using AMAPP.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AMAPP.Web.Controllers
{
    public class AccountBalanceController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountBalanceController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("APIClient");
        }

        // Load the main page
        public ActionResult Index()
        {
            return View();
        }

        // Trigger calculation and fetch the results
        [HttpPost]
        public async Task<ActionResult> CalculateAndFetchBalances()
        {
            try
            {
                // API call to trigger the calculation and fetch balances
                var response = await _httpClient.PostAsync("/api/account-balance/calculatecoproducerbalance", null);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var balances = JsonConvert.DeserializeObject<List<CoproducerAccountBalanceDTO>>(jsonResponse);

                return PartialView("_CoproducerBalances", balances);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                return StatusCode(500, "Error calculating balances.");
            }
        }
    }
}
