using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "Insert into Categories (Name, Status) values (@Name, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", createCategoryDto.Name);
            parameters.Add("@Status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "Delete From Categories Where Id=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * from Categories";
            using (var connction = _context.CreateConnection())
            {
                var values = await connction.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var query = "update Categories set Name = @Name , Status = @Status where Id =@Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", updateCategoryDto.Name);
            parameters.Add("@Status", updateCategoryDto.Status);
            parameters.Add("@Id", updateCategoryDto.Id);
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultCategoryDto> GetAllCategoryByIdAsync(int id)
        {
            string query = "Select * From Categories Where Id=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<ResultCategoryDto>(query, parameters);
                return values;
            }
        }

    }
}
