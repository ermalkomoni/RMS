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
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private DataContext _context;

        public ApplicationUserRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
