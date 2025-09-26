using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<GetPopularLocationDto>> GetAllAsync();
        Task<GetPopularLocationDto> GetPopularLocationByIdAsync(int id);
        Task CreatePopularLocationAsync(CreatePopularLocationDto dto);
        Task DeletePopularLocationAsync(int id);
        Task UpdatePopularLocation(UpdatePopularLocationDto dto);
    }
}
