﻿namespace RealEstate_Dapper_Api.Dtos.TestimonialDtos
{
    public class GetTestimonialDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
    }
}
