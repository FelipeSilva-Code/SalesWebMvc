using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models.Enuns;

namespace SalesWebMvc.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} required")]
        public double Price { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Brand { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        public int Quantity { get; set; }
       
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Product()
        { 
        }

        public Product(int id, string name, double price, string brand, int quantity, Department department)
        {
            Id = id;
            Name = name;
            Price = price;
            Brand = brand;
            Quantity = quantity;
            Department = department;
        }

        public void AddSales(SalesRecord salesRecord)
        {
            Sales.Add(salesRecord);
        }

        public void RemoveSales(SalesRecord salesRecord)
        {
            Sales.Remove(salesRecord);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(x => x.Date >= initial && x.Date <= final).Sum(x => x.Amount);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Product) || obj == null)
                return false;

            Product other = obj as Product;
            return Name.Equals(other.Name) && Brand.Equals(other.Brand);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Brand);
        }
    }
}
