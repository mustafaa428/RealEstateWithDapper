using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateTestimonialAsync(CreateTestimonialDto dto)
        {
            string query = "insert into Testimonial (FullName, Title, Comment, Status) values (@FullName, @Title, @Comment, @Status)";
            var parametres = new DynamicParameters();
            parametres.Add("@FullName", dto.FullName);
            parametres.Add("@Title", dto.Title);
            parametres.Add("@Comment", dto.Comment);
            parametres.Add("@Status", true);
            using(var connect = _context.CreateConnection())
            {
                await connect.ExecuteAsync(query, parametres);
            }
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            string query = "delete from Testimonial where Id = @Id";
            var parametres = new DynamicParameters();
            parametres.Add("@Id", id);
            using(var connect= _context.CreateConnection())
            {
                await connect.ExecuteAsync(query, parametres);
            }
        }

        public async Task<List<GetTestimonialDto>> GetAllAsync()
        {
            string query = "select * from Testimonial";
            using(var  connect = _context.CreateConnection())
            {
                var values = await connect.QueryAsync<GetTestimonialDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetTestimonialDto> GetTestimonialByIdAsync(int id)
        {
            string query = "select * from Testimonial where Id = @Id";
            var parametres = new DynamicParameters();
            parametres.Add("@Id", id);
            using (var connect = _context.CreateConnection())
            {
                var values = await connect.QueryFirstOrDefaultAsync<GetTestimonialDto>(query, parametres);
                return values;
            }
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto dto)
        {
            string query = "update Testimonial set FullName = @FullName, Title = @Title, Comment = @Comment, Status=@Status where Id=@Id";
            var parametres = new DynamicParameters();
            parametres.Add("@FullName", dto.FullName);
            parametres.Add("@Title", dto.Title);
            parametres.Add("@Comment", dto.Comment);
            parametres.Add("@Status", dto.Status);
            parametres.Add("@Id", dto.Id);
            using(var  conn = _context.CreateConnection())
            {
                await conn.ExecuteAsync(query, parametres);
            }
        }
    }
}
