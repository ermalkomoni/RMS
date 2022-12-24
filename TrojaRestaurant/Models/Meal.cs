namespace TrojaRestaurant.Models
{
    public class Meal
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public Category Category { get; set; }

        public string ImageUrl { get; set; }
    }
}
