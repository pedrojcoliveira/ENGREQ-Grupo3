using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AMAPP.Web.Models;

namespace AMAPP.Web.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly HttpClient _httpClient;

        public SubscriptionsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("APIClient");
        }

        // GET: ListSubscriptions
        public async Task<IActionResult> List()
        {
            // Fazer a requisição GET para a API
            var response = await _httpClient.GetStringAsync("/api/selected-product-offer");

            // Deserializar os dados JSON em uma lista de subscrições
            var subscriptions = JsonSerializer.Deserialize<List<SubscriptionViewModel>>(response);

            // Passar os dados para a view
            return View("ListSubscriptions", subscriptions);
        }

        // GET: CreateSubscription
        public IActionResult Create()
        {
            // Criar um modelo vazio para a criação de subscrições
            var model = new SubscriptionViewModel
            {
                CreateSubscriptionPayments = new List<CreateSubscriptionPaymentViewModel>()
            };

            return View("CreateSubscriptions", model);
        }

        // POST: CreateSubscription
        [HttpPost]
        public async Task<IActionResult> Create(SubscriptionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/selected-product-offer", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }

                // Caso o envio da requisição falhe
                ModelState.AddModelError("", "Erro ao criar subscrição.");
            }

            return View("CreateSubscriptions", model);
        }
    }
}
