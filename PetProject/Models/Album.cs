using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataLayer
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        [RegularExpression("^((?!^Title$)[a-zA-Z '])+$", ErrorMessage = "Title is required and must be properly formatted.")]
        public string Title { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageFile { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime CreatedAt { get; set; }

    }
}