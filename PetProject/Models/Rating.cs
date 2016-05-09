using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        // pseudo foreign key
        // Plock: Real FK to Application User difficult in Data Layer and unnecessary
        public string UserId { get; set; }

        [Required]
        // foreign key
        public virtual Song song { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime CreatedAt { get; set; }

        [Required]

        public decimal RatingValue { get; set; }
    }
}