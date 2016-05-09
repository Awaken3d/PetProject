using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public class Play

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // pseudo-foreign key
        // Plock: Real FK to Application User difficult in Data Layer and unnecessary
        public virtual string UserId { get; set; }

        // foreign key
        [Required]
        [Display(Name = "Song Name")]
        public virtual Song song { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime CreatedAt { get; set; }
    }
}