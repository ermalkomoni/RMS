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
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private DataContext _context;

        public ShoppingCartRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            return shoppingCart.Count;  
        }

        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            return shoppingCart.Count;
        }
    }
}
