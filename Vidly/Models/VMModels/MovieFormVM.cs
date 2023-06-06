using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Vidly.Models.DbModels;

namespace Vidly.Models.VMModels
{
    public class MovieFormVM
    {
        public MovieFormVM()
        {
            Id = 0;
        }
        public MovieFormVM(Movie movie)
        {
            Name = movie.Name;
            Id = movie.Id;
            Releasedate = movie.Releasedate;
            GenresId = movie.GenresId;
            Stock = movie.Stock;
        }
        public List<Genres> Genres { get; set; }

        [Required]
        public int? Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [DataType(DataType.DateTime)]
        [Display(Name = "Release Date")]
        [Required]
        public DateTime Releasedate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int Stock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenresId { get; set; }

        public string Title
        {
            get
            {
                if(Id == 0)
                {
                    return "New Movie";
                }
                else
                {
                    return "Edit Movie";
                }
            }
        }
    }
}
