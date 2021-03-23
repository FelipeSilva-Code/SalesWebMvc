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

        public async Task<Product> FindByIdAsync (int? id)
        {
            var product = await _context.Product.Include(x => x.Department)
                                        .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task RemoveAsync (int id)
        {
            try
            {
                var product = await FindByIdAsync(id);
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Can't delete product because it is on sales");
            }
        }

        public async Task UpdateAsync (Product product)
        {
            if (!await _context.Seller.AnyAsync(x => x.Id == product.Id))
                throw new NotFoundException("Id not found");

            try
            {
                _context.Product.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
