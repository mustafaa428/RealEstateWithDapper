using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task CreatePopularLocationAsync(CreatePopularLocationDto dto)
        {
            string query = "insert into PopularLocation (CityName, ImageUrl) values (@CityName , @ImageUrl)";
            var parametres = new DynamicParameters();
            parametres.Add("@CityName", dto.CityName);
            parametres.Add("@ImageUrl", dto.ImageUrl);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }

        public async Task DeletePopularLocationAsync(int id)
        {
            string query = "delete from PopularLocation where Id = @Id";
            var parametres = new DynamicParameters();
            parametres.Add("@Id", id);
            using( var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parametres);
            }
        }

        public async Task<List<GetPopularLocationDto>> GetAllAsync()
        {
            string query = "Select * from PopularLocation";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetPopularLocationDto> GetPopularLocationByIdAsync(int id)
        {
            string query = "select * from PopularLocation where Id=@Id";
            var parametres = new DynamicParameters();
            parametres.Add("@Id", id);
            using(var connecation = _context.CreateConnection())
            {
                var values = await connecation.QueryFirstOrDefaultAsync<GetPopularLocationDto>(query, parametres);
                return values;
            }
        }

        public async Task UpdatePopularLocation(UpdatePopularLocationDto dto)
        {
            string query = "update PopularLocation set CityName = @CityName, ImageUrl = @ImageUrl where Id = @Id";
            var parametres = new DynamicParameters();
            parametres.Add("@Id", dto.Id);
            parametres.Add("@CityName", dto.CityName);
            parametres.Add("@ImageUrl", dto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }
    }
}
