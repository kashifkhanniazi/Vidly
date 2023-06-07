using System.ComponentModel.DataAnnotations;
using System;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Releasedate { get; set; }
        public DateTime Addeddate { get; set; }
        [Range(1, 20)]
        public int Stock { get; set; }
        public byte GenresId { get; set; }
    }
}
