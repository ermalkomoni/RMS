using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrojaRestaurant.Models.Models
{
    public class Review
    {
        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        //[Required]
        //public virtual ApplicationUser ApplicationUser { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [MaxLength(36)]

        public string Summary { get; set; }
    }
}
