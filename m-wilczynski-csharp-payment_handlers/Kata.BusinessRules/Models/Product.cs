using Kata.BusinessRules.Events;

namespace Kata.BusinessRules.Models
{
    public class Product : EventSource
    {
        public string CategoryName { get;set; }
        public string Name { get; set; }
    }
}