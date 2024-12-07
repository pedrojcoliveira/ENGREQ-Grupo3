using AMAPP.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AMAPP.Web.Controllers
{
    public class SubscriptionPeriodController : Controller
    {
        private readonly HttpClient _httpClient;

        public SubscriptionPeriodController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AMAPPClient");
        }

        //-------------------------------------------------------------------------------------------
        //--------------------------------ListSubscriptionPeriod-------------------------------------
        //-------------------------------------------------------------------------------------------
        public async Task<IActionResult> List()
        {
            try
            {
                // Chamada à API
                var response = await _httpClient.GetAsync("/api/subscription-period");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var subscriptionPeriods = JsonConvert.DeserializeObject<IEnumerable<SubscriptionPeriod>>(json);

                // Passa os dados para a View
                return View("ListSubscriptionPeriod", subscriptionPeriods);
            }
            catch
            {
                // Retorna uma página de erro em caso de falha
                return View("Error");
            }
        }

        //-------------------------------------------------------------------------------------------
        //--------------------------------CreateSubsctiptionProduct----------------------------------
        //-------------------------------------------------------------------------------------------
        
        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateSubscriptionPeriod");
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubscriptionPeriod model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateSubscriptionPeriod", model);
            }

            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/subscription-period", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }

                ModelState.AddModelError(string.Empty, "Erro ao criar o Subscription Period. Tente novamente.");
                return View("CreateSubscriptionPeriod", model);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro inesperado.");
                return View("CreateSubscriptionPeriod", model);
            }
        }


        //-------------------------------------------------------------------------------------------
        //--------------------------------EditSubscriptionPeriod-------------------------------------
        //-------------------------------------------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                // Chamada à API para obter os dados do SubscriptionPeriod
                var response = await _httpClient.GetAsync($"/api/subscription-period/{id}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var subscriptionPeriod = JsonConvert.DeserializeObject<SubscriptionPeriod>(json);

                return View("EditSubscriptionPeriod", subscriptionPeriod);
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SubscriptionPeriod model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditSubscriptionPeriod", model);
            }

            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"/api/subscription-period/{model.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }

                ModelState.AddModelError(string.Empty, "Erro ao editar o Subscription Period. Tente novamente.");
                return View("EditSubscriptionPeriod", model);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro inesperado.");
                return View("EditSubscriptionPeriod", model);
            }
        }

        //-------------------------------------------------------------------------------------------
        //--------------------------------DeleteSubscriptionPeriod-----------------------------------
        //-------------------------------------------------------------------------------------------

    }
}
