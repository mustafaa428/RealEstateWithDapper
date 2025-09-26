using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;
using System.Threading.Tasks;

namespace RealEstate_Dapper_UI.ViewComponents.Home
{
    public class DefaultAboutComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultAboutComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44392/api/WhoWeAres");
            var responseMessage2 = await client.GetAsync("https://localhost:44392/api/Services/GetServiceByTrueStatus");
            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultWhoWeAreDto>(jsonData);
                var value2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);
                ViewBag.Title = value.title;
                ViewBag.subtitle = value.subTitle;
                ViewBag.description1 = value.description1;
                ViewBag.description2 = value.description2;
                return View(value2);
            }
            return View();
        }
    }
}
