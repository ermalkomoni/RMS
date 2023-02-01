using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrojaRestaurant.DataAccess.Repository.IRepository;
using TrojaRestaurant.Models;

namespace TrojaRestaurant.DataAccess.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private DataContext _context;

        public OrderRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Order obj)
        {
            _context.Orders.Update(obj);
        }
    }
}
