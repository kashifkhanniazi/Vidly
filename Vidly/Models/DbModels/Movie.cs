using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.DbModels
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Release Date")]
        public DateTime Releasedate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Addeddate { get; set; }
        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        public int Stock { get; set; }
        
        public Genres Genres { get; set; }
        [Display(Name = "Genre")]
        public byte GenresId { get; set; }
    }
}
