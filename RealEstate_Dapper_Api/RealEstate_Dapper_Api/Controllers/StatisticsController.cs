using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;
        public StatisticsController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var result = _statisticRepository.CategoryCount();
            return Ok(result);
        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            var result = _statisticRepository.ActiveCategoryCount();
            return Ok(result);
        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            var result = _statisticRepository.PassiveCategoryCount();
            return Ok(result);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var result = _statisticRepository.ProductCount();
            return Ok(result);
        }
        [HttpGet("ApartmentCount")]
        public IActionResult ApartmentCount()
        {
            var result = _statisticRepository.ApartmentCount();
            return Ok(result);
        }
        [HttpGet("EmployeeNameByMaxproductCount")]
        public IActionResult EmployeeNameByMaxproductCount()
        {
            var result = _statisticRepository.EmployeeNameByMaxProductCount();
            return Ok(result);
        }
        [HttpGet("CategoryNameByMaxproductCount")]
        public IActionResult CategoryNameByMaxproductCount()
        {
            var result = _statisticRepository.CategoryNameByMaxProductCount();
            return Ok(result);
        }
        [HttpGet("AvarageProductBySalePrice")]
        public IActionResult AvarageProductBySalePrice()
        {
            var result = _statisticRepository.AverageProductPriceBySale();
            return Ok(result);
        }
        [HttpGet("AvarageProductByRentPrice")]
        public IActionResult AvarageProductByRentPrice()
        {
            var result = _statisticRepository.AverageProductPriceByRent();
            return Ok(result);
        }
        [HttpGet("CityByMaxApartmentCount")]
        public IActionResult CityByMaxApartmentCount()
        {
            var result = _statisticRepository.CityNameByMaxProductCount();
            return Ok(result);
        }
        [HttpGet("LastProductPrice")]
        public IActionResult LastProductPrice()
        {
            var result = _statisticRepository.LastProductPrice();
            return Ok(result);
        }
        [HttpGet("NewestBuildingYear")]
        public IActionResult NewestBuildingYear()
        {
            var result = _statisticRepository.NewestBuildingYear();
            return Ok(result);
        }

        [HttpGet("OldestBuildingYear")]
        public IActionResult OldestBuildingYear()
        {
            var result = _statisticRepository.OldestBuildingYear();
            return Ok(result);
        }

        [HttpGet("AvarageRoomCount")]
        public IActionResult AvarageRoomCount()
        {
            var result = _statisticRepository.AverageRoomCount();
            return Ok(result);
        }

        [HttpGet("ActiveEmployeeCount")]
        public IActionResult ActiveEmployeeCount()
        {
            var result = _statisticRepository.ActiveEmployeeCount();
            return Ok(result);
        }

        [HttpGet("DifferentCityCount")]
        public IActionResult DifferentCityCount()
        {
            var result = _statisticRepository.DifferentCityCount();
            return Ok(result);
        }

    }
}
