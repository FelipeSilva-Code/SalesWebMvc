using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;

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
                                                 .OrderBy(x => x.Department.Nome)
                                                 .ThenBy(x => x.Name)
                                                 .ToListAsync();
            return products;
        }

        public async Task InsertAsync (Product product)
        {
            List<Product> allProducts = await FindAllAsync();
            
            foreach(Product item in allProducts )
            {
                if (item.Equals(product))
                    throw new EqualException("This product is already registered");
            }
            
            _context.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
