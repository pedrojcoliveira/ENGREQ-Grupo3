using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AMAPP.Web.Models;

namespace AMAPP.Web.Controllers
{
    public class SubscriptionsController : Controller
    {
        // Mock de dados (armazenamento em memória)
        private static List<Subscription> Subscriptions = new()
        {
            new Subscription
            {
                Id = 1,
                CoproducerName = "John Doe",
                PeriodDescription = "January - March 2024",
                Products = new List<string> { "Tomatoes", "Carrots", "Potatoes" },
                TotalPayments = 150.50m
            },
            new Subscription
            {
                Id = 2,
                CoproducerName = "Jane Smith",
                PeriodDescription = "April - June 2024",
                Products = new List<string> { "Apples", "Bananas", "Oranges" },
                TotalPayments = 90.00m
            }
        };

        //-------------------------------------------------------------------------------------------
        //-----------------------------------ListSubscriptions---------------------------------------
        //-------------------------------------------------------------------------------------------
        public IActionResult List()
        {
            // Passa as subscrições para a view "ListSubscriptions"
            return View("ListSubscriptions", Subscriptions);
        }

        //-------------------------------------------------------------------------------------------
        //-----------------------------------CreateSubscription--------------------------------------
        //-------------------------------------------------------------------------------------------

        // GET: Subscriptions/Create
        public IActionResult Create()
        {
            return View("CreateSubscriptions");
        }
    }
}