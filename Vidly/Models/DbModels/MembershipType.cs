using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.DbModels
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public short SingUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set;}
    }
}
