using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class ProductService
    {
        private readonly SalesWebMvcContext _context;

        public ProductService (SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> FindAllAsync ()
        {
            var products = await _context.Product.Include(x => x.Department)
                                                 .OrderBy(x => x.Department)
                                                 .ThenBy(x => x.Name)
                                                 .ToListAsync();
            return products;
        }
    }
}
