using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrojaRestaurant.Models;
using TrojaRestaurant.Models.Models;
using TrojaRestaurant.Utility;

namespace TrojaRestaurant.DataAccess.DbInitializer
{
    public class DbInitializer : IDbinitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _context;

        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, DataContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public void Initialize()
        {
            // migrations if they are not applied
            try
            {
                if(_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
            // create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User)).GetAwaiter().GetResult();

                ApplicationUser user = new ApplicationUser
                {
                    UserName = "ermaladmin@trojarestaurant.com",
                    Name = "ermaladmin@trojarestaurant.com",
                    Email = "ermaladmin@trojarestaurant.com",
                    PhoneNumber = "049222333",
                    StreetAdress = "Peje",
                    City = "Prishtine",
                    State = "Kosova",
                    PostalCode = "30000"
                };

                var result = _userManager.CreateAsync(user, "Ermal@123").GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
                }
            }

            if(_context.Categories.Count() <= 0) { 
                var categories = new List<Category>
                {
                    new Category
                    {
                        Name = "Burgers",
                        DisplayOrder = 1,
                        CreatedDateTime = DateTime.Now
                    },
                    new Category
                    {
                        Name = "Chicken n'Rice",
                        DisplayOrder = 2,
                        CreatedDateTime = DateTime.Now
                    },
                    new Category
                    {
                        Name = "Sandwich",
                        DisplayOrder = 3,
                        CreatedDateTime = DateTime.Now
                    },
                    new Category
                    {
                        Name = "Salad",
                        DisplayOrder = 4,
                        CreatedDateTime = DateTime.Now
                    },
                    new Category
                    {
                        Name = "Extra",
                        DisplayOrder = 5,
                        CreatedDateTime = DateTime.Now
                    },
                    new Category
                    {
                        Name = "Pizza",
                        DisplayOrder = 6,
                        CreatedDateTime = DateTime.Now
                    }
                };
                _context.Categories.AddRange(categories);
                _context.SaveChanges();
            }

            if (_context.Products.Count() <= 0)
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Title = "Chicken Burger",
                        Description = "A burger made with chicken meat, served with lettuce, tomato, and mayonnaise",
                        Price = 3.9,
                        ImageUrl = "/Images/Hebs-Chicken-Burger-1.jpg",
                        CategoryId = 1
                    },
                    new Product
                    {
                        Title = "Pizza Mix",
                        Description = "A mix of various pizza toppings, including pepperoni, sausage, mushrooms, and peppers.",
                        Price = 5.9,
                        ImageUrl = "/Images/pizza-mix.jpg",
                        CategoryId = 6
                    },
                    new Product
                    {
                        Title = "Beef Burger",
                        Description = "A burger made with beef meat, served with lettuce, tomato, and ketchup.",
                        Price = 4.5,
                        ImageUrl = "/Images/Beef-burger.jpg",
                        CategoryId = 1
                    },
                    new Product
                    {
                        Title = "Chicken Sandwich",
                        Description = "A sandwich made with chicken meat, served with lettuce, tomato, and mayonnaise.",
                        Price = 2.8,
                        ImageUrl = "/Images/Chicken-Sandwich.jpg",
                        CategoryId = 3
                    },
                    new Product
                    {
                        Title = "Pizza Pepperoni",
                        Description = "A pizza topped with pepperoni slices and mozzarella cheese.",
                        Price = 5.5,
                        ImageUrl = "/Images/pizza-peperoni.jpg",
                        CategoryId = 6
                    },
                    new Product
                    {
                        Title = "Chicken Salad",
                        Description = "A salad made with chicken meat, lettuce, tomato, cucumber, and dressing.",
                        Price = 2.5,
                        ImageUrl = "/Images/Chicken-Salad-1.jpg",
                        CategoryId = 4
                    },
                    new Product
                    {
                        Title = "Hot Amigos",
                        Description = "A spicy chicken dish served with rice and beans.",
                        Price = 3.9,
                        ImageUrl = "/Images/Hot-Amigos-1.jpg",
                        CategoryId = 2
                    },
                    new Product
                    {
                        Title = "Tenders In Mexico",
                        Description = "Chicken tenders served with rice, beans, and a side of salsa.",
                        Price = 3.9,
                        ImageUrl = "/Images/Tenders-in-Mexico-1.jpg",
                        CategoryId = 2
                    },
                    new Product
                    {
                        Title = "Bucket of Wings",
                        Description = "A bucket of chicken wings served with a side of ranch dressing.",
                        Price = 9.9,
                        ImageUrl = "/Images/bucket-of-wings-hebs.jpg",
                        CategoryId = 5
                    },
                    new Product
                    {
                        Title = "Kids Box",
                        Description = "A special mystery box made with love for kids",
                        Price = 2.9,
                        ImageUrl = "/Images/kids-box.jpg",
                        CategoryId = 5
                    },
                    new Product
                    {
                        Title = "Love Burger",
                        Description = "Made with love for lovers!",
                        Price = 3.5,
                        ImageUrl = "/Images/love-burger.jpg",
                        CategoryId = 1
                    },
                    new Product
                    {
                        Title = "Mozzarella Sticks",
                        Description = "A bucket of mozzarella sticks served with a side of ranch dressing.",
                        Price = 2,
                        ImageUrl = "/Images/MOZZARELLA-STICKS.jpg",
                        CategoryId = 5
                    }
                };
                _context.Products.AddRange(products);
                _context.SaveChanges();

            }
        }   
    }
}
