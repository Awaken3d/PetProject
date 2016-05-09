using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataLayer
{
    public class Playlist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Pseudo foreign-key
        // Plock: Real FK to Application User difficult in Data Layer and unnecessary
        public virtual string User { get; set; }

        [Required]
        [Display(Name = "Playlist Title")]
        [RegularExpression("^((?!^Playlist Title$)[a-zA-Z '])+$", ErrorMessage = "Playlist title is required and must be properly formatted.")]
        public string Title { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime CreatedAt { get; set; }
    }
}