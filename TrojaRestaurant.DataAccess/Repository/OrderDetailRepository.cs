using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrojaRestaurant.DataAccess.Repository.IRepository;
using TrojaRestaurant.Models;
using TrojaRestaurant.Models.Models;

namespace TrojaRestaurant.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private DataContext _context;

        public OrderDetailRepository(DataContext context) : base(context)
        {
            _context = context;
        }


        public void Update(OrderDetail obj)
        {
            _context.OrderDetails.Update(obj);
        }
    }
}
