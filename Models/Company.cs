using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Company
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? StreetAdress { get; set; }
        public string? City { get; set; }
        public int? PostalCode { get; set; }
        public int? PhoneNumber { get; set; }
        
    }
}
