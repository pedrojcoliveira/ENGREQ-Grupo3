using AMAPP.API.DTOs.SubscriptionPayment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace AMAPP.Web.Controllers
{
    public class SubscriptionPaymentController : Controller
    {

        private readonly HttpClient _httpClient;

        public SubscriptionPaymentController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("APIClient");
        }

        // Mock data for demonstration purposes
        private List<CoProducerDebts> coProducerDebts = new List<CoProducerDebts>
        {
            new CoProducerDebts { CoProducerName = "CoProducer A", ProducerName = "Producer X", SubscriptionName = "Subscription 1", Debt = 150.50m },
            new CoProducerDebts { CoProducerName = "CoProducer B", ProducerName = "Producer Y", SubscriptionName = "Subscription 2", Debt = 250.75m }
        };

        private List<ProducerPendingPayments> producerPendingPayments = new List<ProducerPendingPayments>
        {
            new ProducerPendingPayments { CoProducerName = "CoProducer C", ProducerName = "Producer Z", SubscriptionName = "Subscription 3", PendingPayment = 300.00m },
            new ProducerPendingPayments { CoProducerName = "CoProducer D", ProducerName = "Producer W", SubscriptionName = "Subscription 4", PendingPayment = 500.25m }
        };

        // Load the page
        public ActionResult Index()
        {
            // Dropdown options
            ViewBag.Options = new List<SelectListItem>
            {
                new SelectListItem { Value = "CoProducerDebts", Text = "Pagamentos a realizar Co-Producers" },
                new SelectListItem { Value = "ProducerPendingPayments", Text = "Pagamentos a receber pelo Producers" }
            };

            return View();
        }

        // Fetch data based on selection
        [HttpPost]
        public async Task<ActionResult> LoadData(string selectedOption)
        {

            try
            {
                if (selectedOption == "CoProducerDebts")
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, "/api/subscription-payment/coproducersdebts");
                    request.Headers.Add("accept", "text/plain");
                    var response = await _httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var coProducerDebts = JsonConvert.DeserializeObject<List<CoProducerDebts>>(jsonResponse);


                    return PartialView("_CoProducerDebts", coProducerDebts);
                }
                else if (selectedOption == "ProducerPendingPayments")
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, "/api/subscription-payment/producerpendingpayments");
                    request.Headers.Add("accept", "text/plain");
                    var response = await _httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var producerPendingPayments = JsonConvert.DeserializeObject<List<ProducerPendingPayments>>(jsonResponse);

                    return PartialView("_ProducerPendingPayments", producerPendingPayments);
                }

                return BadRequest("Invalid selection");
            }
            catch (HttpRequestException ex)
            {
                // Log and handle HTTP-specific errors
                Console.WriteLine($"Request error: {ex.Message}");
                return StatusCode(500, "Error processing data from API");
            }
            catch (JsonException ex)
            {
                // Log and handle JSON deserialization errors
                Console.WriteLine($"Deserialization error: {ex.Message}");
                return StatusCode(500, "Error processing data from API");
            }
        }


    }
}
