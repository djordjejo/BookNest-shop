using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ShoppingCard
    {
        [Key]
        public Guid Id { get; set; }

        [Range(1,100,ErrorMessage ="Minimum for items is 1 and max is 1000")]
        public int count { get; set; }
        public Guid productId { get; set; }
        [ForeignKey("productId")]
        [ValidateNever]
        public Product product { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]
        [ValidateNever]
        public ApplicationUser applicationUser { get; set; }

    }
}
