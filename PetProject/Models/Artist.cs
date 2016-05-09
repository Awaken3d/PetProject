using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [RegularExpression("^((?!^Artist Name$)[a-zA-Z '])+$", ErrorMessage = "Name is required and must be properly formatted.")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime CreatedAt { get; set; }

        public ICollection<Song> Songs { get; set; }


    }
}