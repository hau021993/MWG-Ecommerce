using MWG_Ecommerce.Data;
using MWG_Ecommerce.DTO;
using MWG_Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MWG_Ecommerce.Service
{
    public class DiscountDetailService
    {
        private readonly ShoppingonlineContext _context;

        public DiscountDetailService(ShoppingonlineContext context)
        {
            _context = context;
        }

        public List<DiscountDetail> GetAllDiscountDetail()
        {
            return _context.DiscountDetails.ToList();
        }

        public List<DiscountDetail> GellAllDiscountByProduct(int? idDiscount)
        {
            var list = _context.DiscountDetails
                .Include(d => d.Discount)
                .Include(d => d.Product)
                .Where(m => m.DiscountId == idDiscount).ToList();
            return list;
        }

        public DiscountDetail FindDiscountDetailById(int id)
        {
            return _context.DiscountDetails.Find(id);
        }

        public async Task<bool> AddDiscountDetail(int idDiscount, DiscountDetail discountDetail)
        {
            discountDetail.DiscountId = idDiscount;
            _context.Add(discountDetail);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDiscountProduct(DiscountDetail discountDetail)
        {
            try
            {
                _context.Remove(discountDetail);
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
