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
    public class SupplierService
    {
        private readonly ShoppingonlineContext _context;

        public SupplierService(ShoppingonlineContext context)
        {
            _context = context;
        }

        public List<Supplier> GetAllSupplier()
        {
            return _context.Suppliers.ToList();
        }

        public Supplier FindSupplierById(int idSupplier)
        {
            return _context.Suppliers.Find(idSupplier);
        }

        public async Task<bool> AddSupplier(Supplier supplier)
        {
            _context.Add(supplier);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSupplier(Supplier supplier)
        {
            _context.Update(supplier);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSupplier(Supplier supplier)
        {
            try
            {
                _context.Remove(supplier);
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
