using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            string query = "Insert into Employee (Name, Title, Email, Phone, ImageUrl, Status) values (@Name, @Title, @Email, @Phone, @ImageUrl, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", createEmployeeDto.Name);
            parameters.Add("@Title", createEmployeeDto.Title);
            parameters.Add("@Email", createEmployeeDto.Email);
            parameters.Add("@Phone", createEmployeeDto.Phone);
            parameters.Add("@ImageUrl", createEmployeeDto.ImageUrl);
            parameters.Add("@Status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            string query = "DELETE FROM Employee WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var connection = _context.CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        await connection.ExecuteAsync(query, parameters, transaction);
                        transaction.Commit(); // başarıyla silinirse commit
                    }
                    catch (Exception)
                    {
                        transaction.Rollback(); // hata olursa geri al
                        throw; // hatayı fırlat ki üst katman da bilsin
                    }
                }
            }
        }


        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * from Employee";
            using (var connction = _context.CreateConnection())
            {
                var values = await connction.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            var query = @"UPDATE Employee 
                  SET Name = @Name, 
                      Title = @Title, 
                      Email = @Email, 
                      Phone = @Phone, 
                      ImageUrl = @ImageUrl, 
                      Status = @Status 
                  WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Name", updateEmployeeDto.Name);
            parameters.Add("@Title", updateEmployeeDto.Title);
            parameters.Add("@Email", updateEmployeeDto.Email);
            parameters.Add("@Phone", updateEmployeeDto.Phone);
            parameters.Add("@ImageUrl", updateEmployeeDto.ImageUrl);
            parameters.Add("@Status", updateEmployeeDto.Status);
            parameters.Add("@Id", updateEmployeeDto.Id);

            using (var connection = _context.CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        await connection.ExecuteAsync(query, parameters, transaction);
                        transaction.Commit(); // Başarılıysa commit
                    }
                    catch
                    {
                        transaction.Rollback(); // Hata olursa rollback
                        throw; // Hatayı üst katmana fırlat
                    }
                }
            }
        }


        public async Task<ResultEmployeeDto> GetAllEmployeeByIdAsync(int id)
        {
            string query = "Select * From Employee Where Id=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<ResultEmployeeDto>(query, parameters);
                return values;
            }
        }
    }
}
