using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepositories;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAresController : ControllerBase
    {
        private readonly IWhoWeAreRepository _repository;

        public WhoWeAresController(IWhoWeAreRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetWhoWeAre()
        {
            var result = await _repository.GetWhoWeAre();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAre(CreateWhoWeAreDto dto)
        {
            if (!await _repository.HasWhoWeAre())
            {
                await _repository.CreateWhoWeAre(dto);
                return Ok("Hakkımızda detayı eklendi");
            }
            return BadRequest("Zaten bir veri var, yenisini ekleyemezsin");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAre(int id)
        {
            await _repository.DeleteWhoWeAre(id);
            return Ok("silme başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAreDto)
        {
            await _repository.UpdateWhoWeAre(updateWhoWeAreDto);
            return Ok("güncelleme başarılı");
        }
    }
}
