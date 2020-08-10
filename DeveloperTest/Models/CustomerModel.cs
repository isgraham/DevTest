using System;

namespace DeveloperTest.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
