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
    public class SizeService
    {
        private readonly ShoppingonlineContext _context;

        public SizeService(ShoppingonlineContext context)
        {
            _context = context;
        }

        public List<Size> GetAllSize()
        {
            return _context.Sizes.ToList();
        }

        public Size FindSizeById(int idSize)
        {
            return _context.Sizes.Find(idSize);
        }

        public async Task<bool> AddSize(Size size)
        {
            _context.Add(size);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSize(Size size)
        {
            _context.Update(size);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSize(Size size)
        {
            try
            {
                _context.Remove(size);
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
