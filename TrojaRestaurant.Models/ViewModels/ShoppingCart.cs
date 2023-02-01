using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrojaRestaurant.Models.ViewModels
{
    public class ShoppingCart
    {


        public string Title { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }  
    }
}
