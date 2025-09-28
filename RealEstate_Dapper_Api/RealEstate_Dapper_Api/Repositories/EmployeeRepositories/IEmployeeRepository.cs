using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
        Task<ResultEmployeeDto> GetAllEmployeeByIdAsync(int id);
        Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        Task DeleteEmployeeAsync(int id);
        Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);
    }
}
