/*using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Builder;
using TrojaRestaurant.Models;
using Microsoft.Extensions.DependencyInjection;

namespace TrojaRestaurant.DataAccess
{
    public class DbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();

                context.Database.EnsureCreated();

                //Order
                *//*if (!context.Orders.Any())
                {
                    context.Orders.AddRange(new List<Order>()
                    {

                        new Order()
                        {
                            Id = 1,
                            TotalPrice = 100,
                            OrderNumber = "132sa3",
                            ShippingPrice = 12.4,
                            Address = "Prishtine",
                            IsComplete = true
                        },
                    });*//*
                    //context.SaveChanges();

                    //Category
                    //if (!context.Categories.Any())
                    //{

                    //}
                    //Meal
                    //if (!context.Meals.Any())
                    //{

                    //}
                    //Product
                    //if (!context.Products.Any())
                    //{

                    //}
                    //Reservation
                    //if (!context.Reservations.Any())
                    //{

                    //}

                //}
            }
        }
    }
}
*/