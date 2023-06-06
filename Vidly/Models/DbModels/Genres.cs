using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.DbModels
{
    public class Genres
    {
        [Key]
        public byte Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
