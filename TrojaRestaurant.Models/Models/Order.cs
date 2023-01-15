using System.ComponentModel.DataAnnotations;

namespace TrojaRestaurant.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "TotalPrice")]
        public double TotalPrice { get; set; }

        [Display(Name = "OrderNumber")]
        public string OrderNumber { get; set; }

        [Display(Name = "ShippingPrice")]
        public double ShippingPrice { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "IsComplete")]
        public bool IsComplete { get; set; }

        //public DateTime? CompletedOn { get; set; }

        //public DateTime DeliveryTime { get; set; }
    }
}