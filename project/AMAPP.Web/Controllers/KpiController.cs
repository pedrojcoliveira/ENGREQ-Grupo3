using AMAPP.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace AMAPP.Web.Controllers
{
    public class KpiController : Controller
    {
        private readonly HttpClient _httpClient;

        public KpiController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("APIClient");
        }

        public ActionResult Index()
        {
            // Pass KPI options to the view
            ViewBag.KpiOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "ProducerDeliveryKpi", Text = "Value Delivered by Producer" },
                new SelectListItem { Value = "CoproducerSubscriptionKpi", Text = "Average Value Subscribed by Co-Producer" }
            };

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoadKpiData(string selectedKpi)
        {
            try
            {
                if (selectedKpi == "ProducerDeliveryKpi")
                {
                    var response = await _httpClient.GetAsync("/api/kpi/getproducerdeliverykpi");
                    response.EnsureSuccessStatusCode();

                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var kpiData = JsonConvert.DeserializeObject<List<ProducerDeliveryKpi>>(jsonResponse);

                    return PartialView("_ProducerDeliveryKpi", kpiData);
                }
                else if (selectedKpi == "CoproducerSubscriptionKpi")
                {
                    var response = await _httpClient.GetAsync("/api/kpi/getcoproducersubscriptionkpi");
                    response.EnsureSuccessStatusCode();

                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var kpiData = JsonConvert.DeserializeObject<List<CoproducerSubscriptionKpi>>(jsonResponse);

                    return PartialView("_CoproducerSubscriptionKpi", kpiData);
                }

                return BadRequest("Invalid KPI selected");
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while loading KPI data");
            }
        }
    }
}
