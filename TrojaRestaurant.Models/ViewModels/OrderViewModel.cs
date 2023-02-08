using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrojaRestaurant.Models.Models;

namespace TrojaRestaurant.Models.ViewModels
{
    public class OrderViewModel
    {
        public OrderHeader OrderHeader { get; set; }    
        public IEnumerable<OrderDetail> OrderDetail { get; set; }
    }
}
