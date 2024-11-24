using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AMAPP.Web.Models; // Verifique se você tem o namespace correto para o seu modelo Product

namespace AMAPP.Web.Controllers
{
    public class ProductsController : Controller
    {
        // Método para exibir a lista de produtos
        public IActionResult List()
        {
            // Dados simulados, pode ser substituído por dados de um banco de dados futuramente
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.0m },
                new Product { Id = 2, Name = "Product 2", Price = 20.0m },
                new Product { Id = 3, Name = "Product 3", Price = 30.0m }
            };

            // Passando a lista de produtos para a view ListProducts.cshtml
            return View("ListProducts", products); // Aqui especificamos o nome correto da view
        }

        // GET: Exibe a página para criar um produto
        [HttpGet]
        public IActionResult Create()
        {
            // Especifica explicitamente o nome da View
            return View("CreateProducts");
        }

        // POST: Recebe os dados do formulário para criar um produto
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                // Salvar o produto no banco de dados
                // _context.Products.Add(model);
                // _context.SaveChanges();

                return RedirectToAction("List");
            }

            // Retorna a mesma View em caso de erro
            return View("CreateProducts", model);
        }
    }

    
}


