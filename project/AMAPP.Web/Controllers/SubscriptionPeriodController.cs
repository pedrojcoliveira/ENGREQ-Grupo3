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
            _httpClient = httpClientFactory.CreateClient("APIClient");
        }

        //-------------------------------------------------------------------------------------------
        //--------------------------------ListSubscriptionPeriod-------------------------------------
        //-------------------------------------------------------------------------------------------
        public async Task<IActionResult> List()
        {
            try
            {
                // Chamada à API
                var response =
                    await _httpClient.GetAsync("/api/subscription-period"); // To show all results use ?show-all=true
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
                var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8,
                    "application/json");

                var response = await _httpClient.PostAsync("/api/subscription-period", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Periodo de subscrição criado com sucesso!";
                    return RedirectToAction("List");
                }

                TempData["ErrorMessage"] = "Erro ao criar o periodo de subscrição. Tente Novamente.";
                return RedirectToAction("Create");
            }
            catch
            {
                TempData["ErrorMessage"] = "Erro inesperado. Tente Novamente.";
                return RedirectToAction("Create");
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
                var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8,
                    "application/json");

                var response = await _httpClient.PatchAsync($"/api/subscription-period/{model.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Periodo de subscrição atualizado com sucesso!";
                    return RedirectToAction("List");

                }

                /*TempData["ErrorMessage"] = "Erro ao editar o periodo de subscrição. Tente novamente.";
                return RedirectToAction("Edit", new { id = model.Id });*/

                TempData["ErrorMessage"] = "Erro ao editar o periodo de subscrição. Tente novamente.";
                TempData.Keep("ErrorMessage");
                return RedirectToAction("Edit", new { id = model.Id });
            }
            catch
            {
                TempData["ErrorMessage"] = "Erro inesperado. Tente Novamente.";
                return RedirectToAction("Edit", new { id = model.Id });
            }
        }

        //-------------------------------------------------------------------------------------------
        //--------------------------------DeleteSubscriptionPeriod-----------------------------------
        //-------------------------------------------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/subscription-period/{id}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var subscriptionPeriod = JsonConvert.DeserializeObject<SubscriptionPeriod>(json);

                return View("DeleteSubscriptionPeriod", subscriptionPeriod);
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/subscription-period/{id}");
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Periodo de subscrição excluído com sucesso!";
                    return RedirectToAction("List");
                }

                TempData["ErrorMessage"] = "Erro ao excluir o periodo de subscrição. Tente novamente.";
                return RedirectToAction("Delete", new { id });
            }
            catch
            {
                TempData["ErrorMessage"] = "Erro inesperado. Tente Novamente.";
                return RedirectToAction("Delete", new { id });
            }
        }

        // Action to fetch the available delivery dates for the selected subscription period
        public async Task<JsonResult> GetDeliveryDatesAsync(int subscriptionPeriodId)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/subscription-period/1/deliverydates");
            request.Headers.Add("accept", "*/*");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var subscriptionPeriod = JsonConvert.DeserializeObject<List<DeliveryDateDto>>(json);

            return Json(subscriptionPeriod);
        }
    }
}
