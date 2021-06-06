using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SellersService
    {

        private readonly SalesWebMvcContext _context;
        public SellersService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public List<Sellers> FindAll()
        {
            return _context.Sellers.ToList();
        }
        public void Insert(Sellers obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
