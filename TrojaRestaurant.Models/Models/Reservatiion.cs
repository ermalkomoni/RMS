using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrojaRestaurant.Models.Models
{
    public class Reservatiion
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        [Required]

        public string Fullname { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        [Required]

        public string PhoneNumber { get; set; }

        [Required]
        public string ReservationNumber { get; set; }

        public DateTime ReservationDate { get; set; }

        public int NumberOfPeople { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
