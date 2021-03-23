using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class SalesRecordServices
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordServices(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {

            var result = await _context.SalesRecord
                         .Include(x => x.Product).Include(x => x.Product.Department)
                         .Include(x => x.Seller).Where(x => x.Date >= minDate
                          && x.Date <= maxDate).ToListAsync();

            return result.OrderByDescending(x => x.Date).ToList();
        }

        public IEnumerable<IGrouping<Department, SalesRecord>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {

            var data = _context.SalesRecord.Include(x => x.Seller)
                       .Include(x => x.Product)
                       .Include(x => x.Product.Department)
                       .Where(x => x.Date >= minDate.Value && x.Date <= maxDate.Value)
                       .ToList().GroupBy(x => x.Product.Department);
            return data;
        }

        public async Task InsertAsync (SalesRecord salesRecord)
        {
            _context.Add(salesRecord);
            await _context.SaveChangesAsync();
        }


    }
}
