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
    public class LoginHistoryService
    {
        private readonly ShoppingonlineContext _context;

        public LoginHistoryService(ShoppingonlineContext context)
        {
            _context = context;
        }

        public List<LoginHistory> GetAllLoginHistory()
        {
            return _context.LoginHistories.ToList();
        }

        public List<LoginHistory> GetAllLoginHistoryByIdUser(int? id)
        {
            if (id == null)
            {
                throw new NotImplementedException();
            }

            var loginHistory = _context.LoginHistories
                .Include(l => l.User)
                .Where(m => m.UserId == id).ToList();
            if (loginHistory == null)
            {
                throw new NotImplementedException();
            }

            return loginHistory;
        }

        public LoginHistory FindLoginHistoryById(int id)
        {
            return _context.LoginHistories.Find(id);
        }

        public async Task<bool> AddLoginHistory(LoginHistory loginHistory)
        {
            _context.Add(loginHistory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMyLoginHistory(LoginHistory loginHistory)
        {
            try
            {
                _context.Remove(loginHistory);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
