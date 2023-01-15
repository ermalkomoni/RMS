namespace TrojaRestaurant.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string ReservationNumber { get; set; }

        public string Fullname { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime ReservationDate { get; set; }

        public int NumberOfPeople { get; set; }

        public string Email { get; set; }
    }
}
