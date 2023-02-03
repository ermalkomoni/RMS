using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrojaRestaurant.Models.Models;

namespace TrojaRestaurant.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public string ApplicationUserId { get; set; }

        public IEnumerable<ShoppingCart> ListCart { get; set; }
        //public double CartTotal { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
