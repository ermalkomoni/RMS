using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrojaRestaurant.DataAccess.Repository.IRepository;
using TrojaRestaurant.Models;

namespace TrojaRestaurant.DataAccess.Repository
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        private DataContext _context;

        public MenuRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Menu obj)
        {
            var objFromDb = _context.Menus.FirstOrDefault(u => u.Id  == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.CategoryId = obj.CategoryId;
                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
