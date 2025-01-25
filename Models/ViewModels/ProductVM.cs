using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
   public class ProductVM
    {
        Product product { get; set; }
        [ValidateNever]
        IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
