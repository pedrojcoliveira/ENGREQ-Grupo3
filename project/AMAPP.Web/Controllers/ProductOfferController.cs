using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using AMAPP.Web.Models;
using Microsoft.Extensions.Logging;

namespace AMAPP.Web.Controllers
{
    public class ProductOfferController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("APIClient");
        }

        // GET: Lista todas as ofertas de produtos
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Product-Offer");

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Erro ao obter as ofertas de produtos: {response.StatusCode}";
                    return View("Error");
                }

                var json = await response.Content.ReadAsStringAsync();
                var productOffers = JsonConvert.DeserializeObject<List<ProductOffer>>(json);

                // Certifique-se de que o modelo não é nulo
                if (productOffers == null)
                {
                    productOffers = new List<ProductOffer>();
                }

                return View("Index", productOffers);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Ocorreu um erro ao tentar carregar as ofertas de produtos: {ex.Message}";
                return View("Error");
            }
        }

        // GET: Formulário para criar uma nova oferta de produto
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                // Buscar produtos da API ou banco de dados
                var productsResponse = await _httpClient.GetAsync("/api/Product");
                var periodsResponse = await _httpClient.GetAsync("/api/Subscription-Period");

                if (productsResponse.IsSuccessStatusCode)
                {
                    var productsJson = await productsResponse.Content.ReadAsStringAsync();
                    ViewBag.Products = JsonConvert.DeserializeObject<List<Product>>(productsJson);
                }
                else
                {
                    ViewBag.Products = new List<Product>();
                    ViewBag.ErrorMessageProducts = "Não foi possível carregar os produtos.";
                }

                if (periodsResponse.IsSuccessStatusCode)
                {
                    var periodsJson = await periodsResponse.Content.ReadAsStringAsync();
                    ViewBag.SubscriptionPeriods = JsonConvert.DeserializeObject<List<SubscriptionPeriod>>(periodsJson);
                }
                else
                {
                    ViewBag.SubscriptionPeriods = new List<SubscriptionPeriod>(); // Fallback vazio
                    ViewBag.ErrorMessagePeriods = "Não foi possível carregar os períodos de assinatura.";
                }

                return View("Create");
            }
            catch (Exception ex)
            {
                // Fallback em caso de erro
                ViewBag.Products = new List<Product>();
                ViewBag.SubscriptionPeriods = new List<SubscriptionPeriod>();
                ViewBag.ErrorMessageProducts = "Erro ao carregar os produtos.";
                ViewBag.ErrorMessagePeriods = "Erro ao carregar os períodos de assinatura.";
                return View("Create");
            }
        }

        // POST: Cria uma nova oferta de produto
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductOffer model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateViewDataForCreate();
                return View("Create", model);
            }

            try
            {
                // Serializar para JSON e enviar para a API
                var jsonContent = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Product-Offer", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                var errorContent = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Erro ao criar a oferta de produto: {response.StatusCode}");
                await PopulateViewDataForCreate();
                return View("Create", model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocorreu um erro inesperado: {ex.Message}");
                await PopulateViewDataForCreate();
                return View("Create", model);
            }
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


        // GET: Formulário para editar uma oferta de produto
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Product-Offer/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Erro ao obter a oferta de produto: {response.StatusCode}";
                    return View("Error");
                }

                var json = await response.Content.ReadAsStringAsync();
                var productOffer = JsonConvert.DeserializeObject<ProductOffer>(json);

                if (productOffer == null)
                {
                    ViewBag.ErrorMessage = "A oferta de produto não foi encontrada.";
                    return View("Error");
                }

                // Carregar produtos e períodos de subscrição para dropdowns
                await PopulateViewDataForCreate();

                return View("Edit", productOffer);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Ocorreu um erro ao tentar carregar a oferta de produto: {ex.Message}";
                return View("Error");
            }
        }

        // POST: Atualiza uma oferta de produto
        [HttpPost]
        public async Task<IActionResult> Edit(ProductOffer model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateViewDataForCreate();
                return View("Edit", model);
            }
            try
            {
                // Serializar para JSON e enviar para a API
                var jsonContent = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"/api/Product-Offer/{model.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, $"Erro ao atualizar a oferta de produto: {response.StatusCode}");
                await PopulateViewDataForCreate();
                return View("Edit", model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocorreu um erro inesperado: {ex.Message}");
                await PopulateViewDataForCreate();
                return View("Edit", model);
            }
        }
    }
}
