using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AMAPP.Web.Models;
using Newtonsoft.Json;

namespace AMAPP.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AMAPPClient");
        }

        //-------------------------------------------------------------------------------------------
        //-------------------------------------- ListProducts----------------------------------------
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

                // Passar os dados para a view
                return View("ListProducts", products);
            }
            catch
            {
                return View("Error");
            }
        }

        //-------------------------------------------------------------------------------------------
        //-------------------------------------- CreateProducts--------------------------------------
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
        public async Task<IActionResult> Create(Product model/*, IFormFile Photo*/)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateProducts", model);
            }

            try
            {
                // Verifica se foi feito upload de um arquivo
                /*if (Photo != null && Photo.Length > 0)
                {
                    // Gera um nome único para a foto
                    var fileName = Path.GetFileName(Photo.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Products", fileName);

                    // Salva a foto na pasta "wwwroot/images/Products"
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Photo.CopyToAsync(stream);
                    }

                    // Salva o caminho relativo da imagem no modelo (para enviar para a API, se necessário)
                    model.Photo = $"/images/Products/{fileName}";
                }*/

                // Serializa o modelo para JSON
                var jsonContent = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                // Chama a API para criar o produto
                var response = await _httpClient.PostAsync("/api/Product", content);

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
        //-------------------------------------- EditProducts----------------------------------------
        //-------------------------------------------------------------------------------------------

        // GET: Editar Produto
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
                /*
                // Verifica se uma nova foto foi enviada
                if (Photo != null && Photo.Length > 0)
                {
                    // Gera um nome único para a foto
                    var fileName = Path.GetFileName(Photo.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Products", fileName);

                    // Salva a nova foto na pasta "wwwroot/images/Products"
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Photo.CopyToAsync(stream);
                    }

                    // Define o caminho relativo da nova imagem no modelo
                    model.Photo = $"/images/Products/{fileName}";
                }*/

                // Serializa o modelo para JSON
                var jsonContent = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                // Chama a API para atualizar o produto
                var response = await _httpClient.PutAsync($"/api/Product/{model.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }

                ModelState.AddModelError(string.Empty, "Erro ao atualizar o produto. Tente novamente.");
                return View("EditProducts", model);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro inesperado.");
                return View("EditProducts", model);
            }
        }




        //-------------------------------------------------------------------------------------------
        //------------------------------------- DeleteProducts---------------------------------------
        //-------------------------------------------------------------------------------------------
    }

}


