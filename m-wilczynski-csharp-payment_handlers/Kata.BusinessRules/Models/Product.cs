using System.Collections.Generic;
using Kata.BusinessRules.Events;

namespace Kata.BusinessRules.Models
{
    public class Product : EventSource
    {
        public HashSet<ProductType> MatchingTypes { get; } = new HashSet<ProductType>();
        public string CategoryName { get;set; }
        public string Name { get; set; }
    }

    //Not ideal, probably would be worth creating some sort of ProductType class and just keep a relationship
    public enum ProductType
    {
        Physical,
        Book,
        MembershipUpgrade,
        MembershipExtensions,
        MembershipActivation,
        Video
    }
}