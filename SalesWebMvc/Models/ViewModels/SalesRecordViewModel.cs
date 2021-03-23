using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enuns;

namespace SalesWebMvc.Models.ViewModels
{
    public class SalesRecordViewModel
    {
        public SalesRecord SalesRecord { get; set; }
        public List<Product> Products { get; set; }
        public List<Seller> Sellers { get; set; } 
    }
}
