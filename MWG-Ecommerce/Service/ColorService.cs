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
    public class ColorService
    {
        private readonly ShoppingonlineContext _context;

        public ColorService(ShoppingonlineContext context)
        {
            _context = context;
        }

        public List<Color> GetAllColor()
        {
            return _context.Colors.ToList();
        }

        public Color FindColorById(int idColor)
        {
            return _context.Colors.Find(idColor);
        }

        public async Task<bool> AddColor(Color color)
        {
            _context.Add(color);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateColor(Color color)
        {
            _context.Update(color);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteColor(Color color)
        {
            try
            {
                _context.Remove(color);
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
