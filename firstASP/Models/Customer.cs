using System.ComponentModel.DataAnnotations;

namespace firstASP.Models
{
    public class Customer
    {
        [Key]
        public string CustomerName { get; set; } = "";

        public string ContactName { get; set; } = "";

        public string Email { get; set; } = "";

        public string Phone { get; set; } = "";

        public string Address { get; set; } = "";

        public string City { get; set; } = "";

        public string State { get; set; } = "";

        public string ZipCode { get; set; } = "";
    }
}