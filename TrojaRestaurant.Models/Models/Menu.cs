namespace TrojaRestaurant.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public IEnumerable<Meal> Meals { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
