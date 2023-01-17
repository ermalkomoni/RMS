using Microsoft.EntityFrameworkCore;
using TrojaRestaurant.Models;
using TrojaRestaurant.Models.Models;

namespace TrojaRestaurant.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("A FALLBACK CONNECTION STRING");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DataContext(DbContextOptions options) : base(options) {}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        //public DbSet<Test> Tests { get; set; }
        //test
        public object SingleOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
 