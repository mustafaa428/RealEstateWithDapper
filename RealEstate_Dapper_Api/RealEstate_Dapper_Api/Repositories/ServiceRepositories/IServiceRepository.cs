using RealEstate_Dapper_Api.Dtos.SerivcesDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepositories
{
    public interface IServiceRepository
    {
        Task<List<GetAllServiceDto>> GetAllServiceAsync();
        Task<GetAllServiceDto> GetServiceByIdAsync(int id);
        Task<List<GetAllServiceDto>> GetServiceStatusAsync();
        Task CreateServiceAsync(CreateServiceDto createServiceDto);
        Task DeleteServiceByIdAsync(int id);
        Task UpdateServiceAsync(UpdateServiceDto updateServiceDto);
    }
}
