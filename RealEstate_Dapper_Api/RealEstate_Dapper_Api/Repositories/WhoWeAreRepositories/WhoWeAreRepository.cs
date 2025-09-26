using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepositories
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        private readonly Context _context;

        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto)
        {
            string query = "insert into WhoWeAreDetail (Title, SubTitle, Description1, Description2) values (@Title, @SubTitle, @Description1, @Description2)";
            var parametres = new DynamicParameters();
            parametres.Add("@Title", createWhoWeAreDto.Title);
            parametres.Add("@SubTitle", createWhoWeAreDto.SubTitle);
            parametres.Add("@Description1", createWhoWeAreDto.Description1);
            parametres.Add("@Description2", createWhoWeAreDto.Description2);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }

        public async Task DeleteWhoWeAre(int id)
        {
            string query = "Delete From WhoWeAreDetail where Id=@Id";
            var parametres = new DynamicParameters();
            parametres.Add("@Id", id);
            using(var  connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parametres);
            }
        }

        public async Task<WhoWeAreDto> GetWhoWeAre()
        {
            string query = "select * From WhoWeAreDetail";
            using(var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<WhoWeAreDto>(query);
                return value;
            }
        }

        public async Task UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAreDto)
        {
            string query = "update WhoWeAreDetail set Title = @Title, Subtitle = @Subtitle, Description1 = @Description1, Description2=@Description2 where Id = @Id";
            var parametres = new DynamicParameters();
            parametres.Add("@Title", updateWhoWeAreDto.Title);
            parametres.Add("@Subtitle", updateWhoWeAreDto.Subtitle);
            parametres.Add("@Description1", updateWhoWeAreDto.Description1);
            parametres.Add("@Description2", updateWhoWeAreDto.Description2);
            parametres.Add("@Id", updateWhoWeAreDto.Id);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }

        public async Task<bool> HasWhoWeAre()
        {
            string query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM WhoWeAreDetail) THEN 1 ELSE 0 END";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<bool>(query);
            }
        }
    }
}
