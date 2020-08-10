using System.ComponentModel.DataAnnotations;

namespace DeveloperTest.Database.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required, MinLength(5)]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
    }
}