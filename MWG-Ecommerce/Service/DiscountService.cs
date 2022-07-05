using MWG_Ecommerce.Data;
using MWG_Ecommerce.DTO;
using MWG_Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWG_Ecommerce.Service
{
    public class DiscountService
    {
        private readonly ShoppingonlineContext _context;

        public DiscountService(ShoppingonlineContext context)
        {
            _context = context;
        }

        public List<Discount> GetAllDiscount()
        {
            return _context.Discounts.ToList();
        }

        public Discount FindDiscountById(int idDiscount)
        {
            return _context.Discounts.Find(idDiscount);
        }

        public async Task<bool> AddDiscount(Discount discount)
        {
            _context.Add(discount);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDiscount(Discount discount)
        {
            _context.Update(discount);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDiscount(Discount discount)
        {
            try
            {
                _context.Remove(discount);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
