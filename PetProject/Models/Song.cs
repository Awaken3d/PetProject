using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public class Song
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Title")]
        [RegularExpression("^((?!^Title$)[a-zA-Z '])+$", ErrorMessage = "Title is required and must be properly formatted.")]
        public string Title { get; set; }

        //foreign key, use virtual class declaration for Album
        // should we leave it as required? songs can be from performances
        [Required]
        [Display(Name = "Album Title")]
        public virtual Album album { get; set; }

        [Required]
        [Display(Name = "Artist Name")]
        [RegularExpression("^((?!^Artist Name$)[a-zA-Z '])+$", ErrorMessage = "Artist name is required and must be properly formatted.")]
        // foreign key
        public virtual Artist artist {get;set;}
        
        [Display(Name = "Genre")]
        [RegularExpression("^((?!^Song Title$)[a-zA-Z '])+$", ErrorMessage = "Genre is required and must be properly formatted.")]

        public string Genre { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Duration {get;set;}
        
        public string AudioFile { get; set; }

        // CreatedAt represents when this song or song file was created
        [DataType(DataType.Time)]
        public DateTime CreatedAt {get;set;}

        // Another pseudo FK
        public string Uploader { get; set; }
        
        public bool Private { get; set; }

    }
}