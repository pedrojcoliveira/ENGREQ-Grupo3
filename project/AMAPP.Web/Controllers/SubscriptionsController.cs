using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
//using System.Text.Json;
using System.Threading.Tasks;
using AMAPP.Web.Models;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;

namespace AMAPP.Web.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly HttpClient _httpClient;

        public SubscriptionsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("APIClient");
        }

        //-------------------------------------------------------------------------------------------
        //------------------------------------ListSubscriptions--------------------------------------
        //-------------------------------------------------------------------------------------------

        // GET: ListSubscriptions
        public async Task<IActionResult> List()
        {
            try
            {
                // Fazer a requisição GET para a API
                var response = await _httpClient.GetAsync("/api/selected-product-offer");

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Erro ao obter as subscrições: {response.StatusCode}";
                    return View("Error");
                }

                var json = await response.Content.ReadAsStringAsync();
                var subscriptions = JsonConvert.DeserializeObject<List<Subscription>>(json);

                // Passar os dados para a view
                return View("ListSubscriptions", subscriptions);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Ocorreu um erro ao tentar carregar as subscrições: {ex.Message}";
                return View("Error");
            }
        }

        //-------------------------------------------------------------------------------------------
        //-----------------------------------CreateSubscriptions-------------------------------------
        //-------------------------------------------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                // Preencher ViewBag com dados necessários
                await PopulateViewDataForCreate();
                return View("CreateSubscriptions");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Erro ao carregar os dados para criação: {ex.Message}";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Subscription model)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(model);
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

        // Método auxiliar para carregar dados do formulário de criação
        private async Task PopulateViewDataForCreate()
        {
            // Carregar produtos
            var productsResponse = await _httpClient.GetAsync("/api/Product");
            if (productsResponse.IsSuccessStatusCode)
            {
                var productsJson = await productsResponse.Content.ReadAsStringAsync();
                ViewBag.Products = JsonConvert.DeserializeObject<List<Product>>(productsJson);
            }
            else
            {
                ViewBag.Products = new List<Product>();
                ViewBag.ErrorMessageProducts = $"Erro ao carregar os produtos: {productsResponse.StatusCode}";
            }

            // Carregar períodos de assinatura
            var periodsResponse = await _httpClient.GetAsync("/api/Subscription-Period");
            if (periodsResponse.IsSuccessStatusCode)
            {
                var periodsJson = await periodsResponse.Content.ReadAsStringAsync();
                ViewBag.SubscriptionPeriods = JsonConvert.DeserializeObject<List<SubscriptionPeriod>>(periodsJson);
            }
            else
            {
                ViewBag.SubscriptionPeriods = new List<SubscriptionPeriod>();
                ViewBag.ErrorMessagePeriods = $"Erro ao carregar os períodos de assinatura: {periodsResponse.StatusCode}";
            }
        }
    }
}
