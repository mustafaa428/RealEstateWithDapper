using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task<ResultCategoryDto> GetAllCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    }
}
