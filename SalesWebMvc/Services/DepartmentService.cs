using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Department> FindByIdAsync(int id)
        {
            var departement = await _context.Departamento.FirstOrDefaultAsync(x => x.Id == id);

            return departement;
        }

        public async Task InsertAsync (Department department)
        {
            _context.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync (Department department)
        {
            if (!await _context.Departamento.AnyAsync(x => x.Id == department.Id))
                throw new NotFoundException("Id not found");

            try
            {
                _context.Update(department);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task RemoveAsync (int id)
        {
            try
            {
                var department = await FindByIdAsync(id);
                _context.Departamento.Remove(department);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Can't delete this department because it has products and/or sellers");
            }
        }
    }
}
