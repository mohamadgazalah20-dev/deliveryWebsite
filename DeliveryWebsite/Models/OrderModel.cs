namespace DeliveryWebsite.Models
{
    public class OrderModel
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string OrderDetails { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }  // خط العرض
        public double Longitude { get; set; }
    }
}