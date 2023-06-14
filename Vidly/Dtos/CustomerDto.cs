using System.ComponentModel.DataAnnotations;
using System;
using Vidly.Models.ModelValidations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto membershipType { get; set; }
    }
}
