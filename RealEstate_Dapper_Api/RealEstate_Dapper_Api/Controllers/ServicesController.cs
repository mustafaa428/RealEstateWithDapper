using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.SerivcesDtos;
using RealEstate_Dapper_Api.Repositories.ServiceRepositories;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _repository;

        public ServicesController(IServiceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceList()
        {
            var result = await _repository.GetAllServiceAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var result = await _repository.GetServiceByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _repository.DeleteServiceByIdAsync(id);
            return Ok("Hizmet silindi");
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto dto)
        {
            await _repository.CreateServiceAsync(dto);
            return Ok("Hizmet eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto dto)
        {
            await _repository.UpdateServiceAsync(dto);
            return Ok("Hizmet güncellendi");
        }

        [HttpGet("GetServiceByTrueStatus")]
        public async Task<IActionResult> GetServiceByTrueStatus()
        {
            var result = await _repository.GetServiceStatusAsync();
            return Ok(result);
        }

    }
}
