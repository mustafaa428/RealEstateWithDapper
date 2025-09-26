using Dapper;
using RealEstate_Dapper_Api.Dtos.SerivcesDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            string query = "insert into Service (Name, Status) values (@Name, @Status)";
            var parametres = new DynamicParameters();
            parametres.Add("@Name", createServiceDto.Name);
            parametres.Add("@Status", true);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }

        public async Task DeleteServiceByIdAsync(int id)
        {
            string query = "Delete from Service where Id = @Id";
            var parametres = new DynamicParameters();
            parametres.Add("@Id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.ExecuteAsync(query, parametres);
            }
        }

        public async Task<List<GetAllServiceDto>> GetAllServiceAsync()
        {
            string query = "select * from Service";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetAllServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetAllServiceDto> GetServiceByIdAsync(int id)
        {
            string query = "select * from Service where Id = @Id";
            var parametres = new DynamicParameters();
            parametres.Add("@Id", id);
            using(var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstAsync<GetAllServiceDto>(query, parametres);
                return value;
            }
        }

        public async Task<List<GetAllServiceDto>> GetServiceStatusAsync()
        {
            string query = "select * from Service where Status = 1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetAllServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            string query = "Update Service set Name = @Name, Status = @Status where Id = @Id";
            var parametres = new DynamicParameters();
            parametres.Add("@Id", updateServiceDto.Id);
            parametres.Add("@Name", updateServiceDto.Name);
            parametres.Add("@Status", updateServiceDto.Status);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }
    }
}
