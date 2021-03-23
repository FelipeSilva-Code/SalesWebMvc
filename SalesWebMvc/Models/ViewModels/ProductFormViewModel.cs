using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;

namespace SalesWebMvc.Models.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
