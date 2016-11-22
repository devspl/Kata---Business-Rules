using Kata.BusinessRules.Events;

namespace Kata.BusinessRules.Models
{
    public class Product : EventSource
    {
        //These all are just random properties for handlers selectors
        public bool IsPhysical { get; set; }
        public string CategoryName { get;set; }
        public string SubcategoryName { get;set; }
        public string Name { get; set; }
    }
}