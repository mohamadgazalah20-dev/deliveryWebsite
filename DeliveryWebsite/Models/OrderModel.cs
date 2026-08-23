namespace DeliveryWebsite.Models
{
    public class OrderModel
    {
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string OrderDetails { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        
        // يجب أن تكون من نوع string وليس double
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
    }
}