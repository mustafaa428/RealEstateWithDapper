namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class UpdatePrdocutDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public int price { get; set; }
        public string coverImageUrl { get; set; }
        public string city { get; set; }
        public string discrit { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public int employeeId { get; set; }
    }
}
