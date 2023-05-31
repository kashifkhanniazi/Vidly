using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.DbModels
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipId { get; set; }

    }
}
