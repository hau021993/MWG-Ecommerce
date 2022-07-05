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
    public class AccountService
    {
        private readonly ShoppingonlineContext _context;

        public AccountService(ShoppingonlineContext context)
        {
            _context = context;
        }

        public List<User> GetAllUser()
        {
            return _context.Users.Where(a => a.Status == "Offline" || a.Status == null).ToList();
        }

        public User FindUserById(int idUser)
        {
            return _context.Users.Find(idUser);
        }

        public async Task<bool> AddUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(User user)
        {
            try
            {
                _context.Remove(user);
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
