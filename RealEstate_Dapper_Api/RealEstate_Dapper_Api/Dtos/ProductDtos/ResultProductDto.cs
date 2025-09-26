namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string CoverImageUrl { get; set; }
        public string City { get; set; }
        public string Discrit { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }
        public int EmployeeId { get; set; }
    }
}
