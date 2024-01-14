namespace Services.CuponAPI.Models.Dto
{
    // DTO -> The primary purpose of a DTO is to encapsulate and transport data across different layers of an application, providing a way to transfer structured data without exposing the internal details of the underlying system
    // when sending this data to the frontend, the CouponDto IS USED to encapsulate only the necessary information and structure
    public class CouponDto
    {
        public int CouponId { get; set; }

        public string CouponCode { get; set; }

        public double DiscontAmount { get; set; } //how much discount will someone get

        public int MinAmount { get; set; }
    }
}
