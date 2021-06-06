using System;
using SalesWebMvc.Models;
using System.Linq;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;
        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Sellers.Any () ||
                _context.SalesRecord.Any())
                {
                return; // DB has been seeded

                }
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Sellers s1 = new Sellers(1, "Bob Christina", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Sellers s2 = new Sellers(2, "Christina Aguilera", "Cristina@gmail.com", new DateTime(1999, 5, 20), 1000.0, d2);
            Sellers s3 = new Sellers(3, "Whitney Houston", "houston@gmail.com", new DateTime(2000, 4, 21), 1000.0, d3);
            Sellers s4 = new Sellers(4, "Chris Brown", "brown@gmail.com", new DateTime(1997, 4, 21), 1000.0, d4);
            Sellers s5 = new Sellers(5, "Chris Rock", "roc@gmail.com", new DateTime(1999, 4, 21), 1000.0, d2);
            Sellers s6 = new Sellers(6, "Gercia Elezuo", "gf@gmail.com", new DateTime(1992, 9, 5), 1000.0, d3);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2021, 09, 25), 11000.0, SalesStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2021, 09, 25), 11000.0, SalesStatus.Canceled, s6);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2021, 09, 25), 11000.0, SalesStatus.Pending, s2);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2021, 09, 25), 11000.0, SalesStatus.Billed, s1);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2021, 09, 25), 11000.0, SalesStatus.Billed, s1);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2021, 09, 25), 11000.0, SalesStatus.Billed, s1);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Sellers.AddRange(s1, s2, s3, s4, s5, s6);

            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6);

            _context.SaveChanges();


        }
    }
}
