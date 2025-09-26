using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<GetBottomGridDto>> GetAllAsync();
        Task<GetBottomGridDto> GetBottomGridByIdAsync(int id);
        Task CreateBottomGridAsync(CreateBottomGridDto dto);
        Task DeleteBottomGridAsync(int id);
        Task UpdateBottomGrid(UpdateBottomGridDto dto);
    }
}
