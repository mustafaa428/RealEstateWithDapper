using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

    public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44392/api/Products/GetProductWithCategoryName");

            if (response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadFromJsonAsync<List<ResultProductWithCategoryNameDto>>();
                return View(products);
            }

            return View(new List<ResultProductWithCategoryNameDto>());
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            await LoadCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto createProductDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:44392/api/Products", createProductDto);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, "Ürün eklenirken hata oluştu.");
            }

            // Hata varsa kategorileri tekrar yükle
            await LoadCategoriesAsync();
            return View(createProductDto);
        }

        private async Task LoadCategoriesAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44392/api/Categories");

            if (response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();

                ViewBag.Categories = categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
            }
            else
            {
                ViewBag.Categories = new List<SelectListItem>();
            }
        }
    }
}
