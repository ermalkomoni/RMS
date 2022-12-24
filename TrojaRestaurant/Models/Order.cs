namespace TrojaRestaurant.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }

        public string OrderNumber { get; set; }

        public double ShippingPrice { get; set; }

        public string Address { get; set; }

        public bool IsComplete { get; set; }

        public DateTime? CompletedOn { get; set; }

        public DateTime DeliveryTime { get; set; }
    }
}
