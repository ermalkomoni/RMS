using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrojaRestaurant.DataAccess.Repository.IRepository;
using TrojaRestaurant.Models;

namespace TrojaRestaurant.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);                //dbSet
            Product = new ProductRepository(_context);                  //dbSet
            Order = new OrderRepository(_context);                      //dbSet
            ApplicationUser = new ApplicationUserRepository(_context);
            ShoppingCart = new ShoppingCartRepository(_context);
            OrderHeader = new OrderHeaderRepository(_context);
            OrderDetail = new OrderDetailRepository(_context);
        }
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; } 
        public IOrderDetailRepository OrderDetail { get; private set; }

        public void Save()                                 //SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
