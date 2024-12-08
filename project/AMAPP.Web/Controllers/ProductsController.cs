                using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AMAPP.Web.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AMAPP.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("APIClient");
        }

        //-------------------------------------------------------------------------------------------
        //--------------------------------------ListProducts----------------------------------------
        //-------------------------------------------------------------------------------------------
        public async Task<IActionResult> List()
        {
            try
            {
                // Chamar a API para obter os produtos
                var response = await _httpClient.GetAsync("/api/Product"); // Endpoint para getAllProducts

                // Verificar se a resposta foi bem-sucedida
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                // Ler e desserializar os dados da resposta
                var json = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(json);

                // Transformar as fotos para Base64
                foreach (var product in products)
                {
                    if (product.Photo != null)
                    {
                        product.PhotoBase64 = $"data:image/png;base64,{Convert.ToBase64String(product.Photo)}";
                    }
                }

                // Passar os dados para a view
                return View("ListProducts", products);
            }
            catch
            {
                return View("Error");
            }
        }

        //-------------------------------------------------------------------------------------------
        //--------------------------------------ProductById-----------------------------------------
        //-------------------------------------------------------------------------------------------
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                // Chamar a API para obter os detalhes do produto
                var response = await _httpClient.GetAsync($"/api/Product/{id}"); // Endpoint para getProductById

                // Verificar se a resposta foi bem-sucedida
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                // Ler e desserializar os dados da resposta
                var json = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(json);

                // Transformar a foto para Base64
                if (product.Photo != null)
                {
                    product.PhotoBase64 = $"data:image/png;base64,{Convert.ToBase64String(product.Photo)}";
                }

                // Passar o produto para a view
                return View("ProductById", product);
            }
            catch
            {
                return View("Error");
            }
        }

        //-------------------------------------------------------------------------------------------
        //--------------------------------------CreateProducts--------------------------------------
        //-------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Create()
        {
            //Para implementar mais tarde para o ProductType
            /*var productTypes = await _httpClient.GetFromJsonAsync<List<ProductType>>("/api/ProductTypes"); // Modifique o endpoint conforme necessário
            ViewBag.ProductTypes = productTypes; // Passa os tipos de produto para a view*/
            return View("CreateProducts");
        }

        // POST: Recebe os dados do formulário para criar um produto
        [HttpPost]
        public async Task<IActionResult> Create(Product model, IFormFile Photo)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateProducts", model);
            }

            try
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(model.Name), "Name");
                content.Add(new StringContent(model.Description), "Description");
                content.Add(new StringContent(model.ReferencePrice.ToString("F2")), "ReferencePrice");
                content.Add(new StringContent(model.DeliveryUnit.ToString()), "DeliveryUnit");
                content.Add(new StringContent(model.ProductTypeId.ToString()), "ProductTypeId");

                if (Photo != null && Photo.Length > 0)
                {
                    var fileContent = new StreamContent(Photo.OpenReadStream());
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(Photo.ContentType);
                    content.Add(fileContent, "Photo", Photo.FileName);
                }

                var request = new HttpRequestMessage(HttpMethod.Post, "/api/product")
                {
                    Content = content
                };

                request.Headers.Add("accept", "text/plain");

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }

                ModelState.AddModelError(string.Empty, "Erro ao criar o produto. Tente novamente.");
                return View("CreateProducts", model);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro inesperado.");
                return View("CreateProducts", model);
            }
        }


        //-------------------------------------------------------------------------------------------
        //---------------------------------------EditProducts----------------------------------------
        //-------------------------------------------------------------------------------------------

        // GET: Editar Produto
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                // Chama a API para obter o produto pelo id
                var response = await _httpClient.GetAsync($"/api/Product/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                var json = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(json);

                return View("EditProducts", product); // Retorna a view de edição com os dados do produto
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: Editar Produto
        [HttpPost]
        public async Task<IActionResult> Edit(Product model, IFormFile Photo)
        {
            if (!ModelState.IsValid)
            {
                return View("EditProducts", model);
            }

            try
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(model.Name), "Name");
                content.Add(new StringContent(model.Description), "Description");
                content.Add(new StringContent(model.ReferencePrice.ToString("F2")), "ReferencePrice");
                content.Add(new StringContent(model.DeliveryUnit.ToString()), "DeliveryUnit");
                content.Add(new StringContent(model.ProductTypeId.ToString()), "ProductTypeId");

                if (Photo != null && Photo.Length > 0)
                {
                    var fileContent = new StreamContent(Photo.OpenReadStream());
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(Photo.ContentType);
                    content.Add(fileContent, "Photo", Photo.FileName);
                }

                var request = new HttpRequestMessage(HttpMethod.Put, $"/api/product/{model.Id}")
                {
                    Content = content
                };
                request.Headers.Add("accept", "text/plain");

                var response = await _httpClient.SendAsync(request);

                var errorContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }

                ModelState.AddModelError(string.Empty, "Erro ao editar o produto. Tente novamente.");
                return View("EditProducts", model);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro inesperado.");
                return View("EditProducts", model);
            }
        }




        //-------------------------------------------------------------------------------------------
        //-------------------------------------DeleteProducts---------------------------------------
        //-------------------------------------------------------------------------------------------
    }

}


