namespace Services.CuponAPI.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }

        public string CouponCode { get; set; }

        public double DiscontAmount { get; set; } //how much discount will someone get

        public int MinAmount { get; set; }
    }
}
