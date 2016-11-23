using System;

namespace Kata.BusinessRules.Models
{
    //Assumes that payment is made for product, that is already created through some sort of Membership domain context
    public class MembershipProduct : Product
    {
        public MembershipPurchaseAction PurchaseAction { get; set; }
        public Guid MembershipId { get; }

        public MembershipProduct(Guid membershipId)
        {
            if (membershipId == null || membershipId.Equals(Guid.Empty))
                throw new ArgumentNullException(nameof(membershipId));
            MembershipId = membershipId;
        }
    }

    public enum MembershipPurchaseAction
    {
        Activation,
        Upgrade,
        Extension
    }
}