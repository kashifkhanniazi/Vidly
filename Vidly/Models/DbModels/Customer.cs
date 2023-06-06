using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models.ModelValidations;

namespace Vidly.Models.DbModels
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        [DataType(DataType.Date)]
        [Display( Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}
