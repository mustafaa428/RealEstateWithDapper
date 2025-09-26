using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepositories
{
    public interface IWhoWeAreRepository
    {
        Task<WhoWeAreDto> GetWhoWeAre();
        Task CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto);
        Task UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAreDto);
        Task DeleteWhoWeAre(int id);
        Task<bool> HasWhoWeAre();
    }
}
