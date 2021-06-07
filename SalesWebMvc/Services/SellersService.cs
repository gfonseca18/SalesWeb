using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;

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
        public Sellers FindById(int id)
        {
            return _context.Sellers.Include (obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Sellers.Find(id);
            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Sellers obj)
        {
            bool hasAny = await _context.Sellers.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundExceptions("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);//excession from Databseservice segregate layers
            }
        }

    }
}
