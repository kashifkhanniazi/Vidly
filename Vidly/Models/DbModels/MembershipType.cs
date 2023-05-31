namespace Vidly.Models.DbModels
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SingUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set;}
    }
}
