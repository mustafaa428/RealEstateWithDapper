using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateBottomGridAsync(CreateBottomGridDto dto)
        {
            string query = "insert into BottomGrid (Icon, Title, Description) values (@Icon, @Title, @Description)";
            var parametres = new DynamicParameters();
            parametres.Add("@Icon", dto.Icon);
            parametres.Add("@Title", dto.Title);
            parametres.Add("@Description", dto.Description);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }

        public async Task DeleteBottomGridAsync(int id)
        {
            string query = "delete from BottomGrid where Id=@Id";
            var parametres = new DynamicParameters();
            parametres.Add("@Id", id);
            using( var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parametres);
            }
        }

        public async Task<List<GetBottomGridDto>> GetAllAsync()
        {
            string query = "select * from BottomGrid";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetBottomGridDto> GetBottomGridByIdAsync(int id)
        {
            string query = "select * from BottomGrid where Id = @Id";
            var parametres = new DynamicParameters();
            parametres.Add("@Id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstAsync<GetBottomGridDto>(query,parametres);
                return values;
            }
        }

        public async Task UpdateBottomGrid(UpdateBottomGridDto dto)
        {
            string query = "update BottomGrid set Icon = @Icon, Title = @Title, Description = @Description where Id = @Id";
            var parametres = new DynamicParameters();
            parametres.Add("@Icon", dto.Icon);
            parametres.Add("@Title", dto.Title);
            parametres.Add("@Description", dto.Description);
            parametres.Add("@Id", dto.Id);
            using(var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parametres);
            }
        }
    }
}
