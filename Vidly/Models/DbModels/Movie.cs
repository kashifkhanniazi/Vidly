using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.DbModels
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
