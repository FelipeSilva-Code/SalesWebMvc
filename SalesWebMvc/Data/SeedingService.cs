using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enuns;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        // Put some records in the DB
        public void Seed()
        {
            if (_context.Departamento.Any() || _context.Seller.Any() ||
                _context.Product.Any() || _context.SalesRecord.Any())
                return; //DB has been seeded

            Department d1 = new Department(1, "Eletronics");
            Department d2 = new Department(2, "Books");
            Department d3 = new Department(3, "Sports");
            Department d4 = new Department(4, "Clothes");
            Department d5 = new Department(5, "Toys");
            Department d6 = new Department(6, "Cosmetics");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Seller s6 = new Seller(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            Product p1 = new Product(1, "Computer 1TB HD e 8GB de Ram", 1500, "Azus", 5, d1);
            Product p2 = new Product(2, "The hate u give", 100, "Amazon", 15, d2);
            Product p3 = new Product(3, "Nike Dunk", 1500, "Nike", 11, d3);
            Product p4 = new Product(4, "White Shirt", 80, "Polo", 19, d4);
            Product p5 = new Product(5, "Buzz Lightyear", 110, "Toy Story", 8, d5);
            Product p6 = new Product(6, "Skin Care", 65, "Avon", 3, d6);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), p1.Price, SaleStatus.Billed, s1, p1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 09, 4), p5.Price, SaleStatus.Billed, s5, p5);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 09, 13), p4.Price, SaleStatus.Canceled, s4, p4);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 09, 1), p1.Price, SaleStatus.Billed, s1, p1);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 09, 21), p3.Price, SaleStatus.Billed, s3, p3);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 09, 15), p1.Price, SaleStatus.Billed, s1, p1);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 09, 28), p2.Price, SaleStatus.Billed, s2, p2);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 09, 11), p4.Price, SaleStatus.Billed, s4, p4);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2018, 09, 14), p6.Price, SaleStatus.Pending, s6, p6);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2018, 09, 7), p6.Price, SaleStatus.Billed, s6, p6);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2018, 09, 13), p2.Price, SaleStatus.Billed, s2, p2);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2018, 09, 25), p3.Price, SaleStatus.Pending, s3, p3);
            SalesRecord r13 = new SalesRecord(13, new DateTime(2018, 09, 29), p4.Price, SaleStatus.Billed, s4, p4);
            SalesRecord r14 = new SalesRecord(14, new DateTime(2018, 09, 4), p5.Price, SaleStatus.Billed, s5, p5);
            SalesRecord r15 = new SalesRecord(15, new DateTime(2018, 09, 12), p1.Price, SaleStatus.Billed, s1, p1);
            SalesRecord r16 = new SalesRecord(16, new DateTime(2018, 10, 5), p4.Price, SaleStatus.Billed, s4, p4);
            SalesRecord r17 = new SalesRecord(17, new DateTime(2018, 10, 1), p1.Price, SaleStatus.Billed, s1, p1);
            SalesRecord r18 = new SalesRecord(18, new DateTime(2018, 10, 24), p3.Price, SaleStatus.Billed, s3, p3);
            SalesRecord r19 = new SalesRecord(19, new DateTime(2018, 10, 22), p5.Price, SaleStatus.Billed, s5, p5);
            SalesRecord r20 = new SalesRecord(20, new DateTime(2018, 10, 15), p6.Price, SaleStatus.Billed, s6, p6);
            SalesRecord r21 = new SalesRecord(21, new DateTime(2018, 10, 17), p2.Price, SaleStatus.Billed, s2, p2);
            SalesRecord r22 = new SalesRecord(22, new DateTime(2018, 10, 24), p4.Price, SaleStatus.Billed, s4, p4);
            SalesRecord r23 = new SalesRecord(23, new DateTime(2018, 10, 19), p2.Price, SaleStatus.Canceled, s2, p2);
            SalesRecord r24 = new SalesRecord(24, new DateTime(2018, 10, 12), p5.Price, SaleStatus.Billed, s5, p5);
            SalesRecord r25 = new SalesRecord(25, new DateTime(2018, 10, 31), p3.Price, SaleStatus.Billed, s3, p3);
            SalesRecord r26 = new SalesRecord(26, new DateTime(2018, 10, 6), p4.Price, SaleStatus.Billed, s4, p4);
            SalesRecord r27 = new SalesRecord(27, new DateTime(2018, 10, 13), p1.Price, SaleStatus.Pending, s1, p1);
            SalesRecord r28 = new SalesRecord(28, new DateTime(2018, 10, 7), p3.Price, SaleStatus.Billed, s3, p3);
            SalesRecord r29 = new SalesRecord(29, new DateTime(2018, 10, 23), p5.Price, SaleStatus.Billed, s5, p5);
            SalesRecord r30 = new SalesRecord(30, new DateTime(2018, 10, 12), p2.Price, SaleStatus.Billed, s2, p2);

            _context.Departamento.AddRange(d1, d2, d3, d4, d5, d6);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            _context.Product.AddRange(p1, p2, p3, p4, p5, p6);

            _context.SalesRecord.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();
        }
    }
}
