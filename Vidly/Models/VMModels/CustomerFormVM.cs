using System.Collections;
using System.Collections.Generic;
using Vidly.Models.DbModels;

namespace Vidly.Models.VMModels
{
    public class CustomerFormVM
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}
