using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using System.Threading.Tasks;

namespace RealEstate_Dapper_UI.ViewComponents.Home
{
    public class DefaultProductListComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultProductListComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44392/api/Products/GetProductWithCategoryName");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryNameDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
