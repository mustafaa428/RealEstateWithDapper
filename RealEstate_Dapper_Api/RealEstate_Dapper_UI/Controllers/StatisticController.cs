using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            #region Kategori Sayısı
            var response = await client.GetAsync("https://localhost:44392/api/Statistics/CategoryCount");
            var content = await response.Content.ReadAsStringAsync();
            #endregion

            #region Aktif Kategori Sayısı
            var response2 = await client.GetAsync("https://localhost:44392/api/Statistics/ActiveCategoryCount");
            var content2 = await response2.Content.ReadAsStringAsync();
            #endregion

            #region Pasif Kategori Sayısı
            var response3 = await client.GetAsync("https://localhost:44392/api/Statistics/PassiveCategoryCount");
            var content3 = await response3.Content.ReadAsStringAsync();
            #endregion

            #region Ürün Sayısı
            var response4 = await client.GetAsync("https://localhost:44392/api/Statistics/ProductCount");
            var content4 = await response4.Content.ReadAsStringAsync();
            #endregion

            #region Daire Sayısı
            var response5 = await client.GetAsync("https://localhost:44392/api/Statistics/ApartmentCount");
            var content5 = await response5.Content.ReadAsStringAsync();
            #endregion

            #region En Çok Ürünü Olan Çalışan Adı
            var response6 = await client.GetAsync("https://localhost:44392/api/Statistics/EmployeeNameByMaxproductCount");
            var content6 = await response6.Content.ReadAsStringAsync();
            #endregion

            #region En Çok Ürünü Olan Kategori Adı
            var response7 = await client.GetAsync("https://localhost:44392/api/Statistics/CategoryNameByMaxproductCount");
            var content7 = await response7.Content.ReadAsStringAsync();
            #endregion

            #region Satış Fiyatı Ortalaması
            var response8 = await client.GetAsync("https://localhost:44392/api/Statistics/AvarageProductBySalePrice");
            var content8 = await response8.Content.ReadAsStringAsync();
            #endregion

            #region Toplam Kiradaki Ürün fiyat ortalaması
            var response9 = await client.GetAsync("https://localhost:44392/api/Statistics/AvarageProductByRentPrice");
            var content9 = await response9.Content.ReadAsStringAsync();
            #endregion

            #region Maksimum Daire Sayısına Sahip Şehir
            var response10 = await client.GetAsync("https://localhost:44392/api/Statistics/CityByMaxApartmentCount");
            var content10 = await response10.Content.ReadAsStringAsync();
            #endregion

            #region Son eklenen Ürünün Fiyatı
            var response11 = await client.GetAsync("https://localhost:44392/api/Statistics/LastProductPrice");
            var content11 = await response11.Content.ReadAsStringAsync();
            #endregion

            #region En Yeni Bina Yılı 
            var response12 = await client.GetAsync("https://localhost:44392/api/Statistics/NewestBuildingYear");
            var content12 = await response12.Content.ReadAsStringAsync();
            #endregion

            #region En Eski Bina Yılı
            var response13 = await client.GetAsync("https://localhost:44392/api/Statistics/OldestBuildingYear");
            var content13 = await response13.Content.ReadAsStringAsync();
            #endregion

            #region Ortalama Oda Sayısı
            var response14 = await client.GetAsync("https://localhost:44392/api/Statistics/AvarageRoomCount");
            var content14 = await response14.Content.ReadAsStringAsync();
            #endregion

            #region Aktif Çalışan Sayısı
            var response15 = await client.GetAsync("https://localhost:44392/api/Statistics/ActiveEmployeeCount");
            var content15 = await response15.Content.ReadAsStringAsync();
            #endregion

            #region Farklı Şehir Sayısı
            var response16 = await client.GetAsync("https://localhost:44392/api/Statistics/DifferentCityCount");
            var content16 = await response16.Content.ReadAsStringAsync();
            #endregion

            ViewBag.CategoryCount = content;
            ViewBag.ActiveCategoryCount = content2;
            ViewBag.PasiveCategoryCount = content3;
            ViewBag.ProductCount = content4;
            ViewBag.ApartmentCount = content5;
            ViewBag.EmployeeMaxProduct = content6;
            ViewBag.MaxCategoryName = content7;
            ViewBag.AvarageSalePrice = content8;
            ViewBag.AvarageRentPrice = content9;
            ViewBag.MaxCityName = content10;
            ViewBag.LastProductPrice = content11;
            ViewBag.NewestBuildingYear = content12;
            ViewBag.OldestBuildingYear = content13;
            ViewBag.AvarageRoomCount = content14;
            ViewBag.ActiveEmployeeCount = content15;
            ViewBag.DifferentCityCount = content16;

            return View();
        }
    }
}
