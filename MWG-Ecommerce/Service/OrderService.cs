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
    public class OrderService
    {
        private readonly ShoppingonlineContext _context;

        public OrderService(ShoppingonlineContext context)
        {
            _context = context;
        }

        public List<Order> GetAllOrder()
        {
            return _context.Orders.Include(o => o.User).Include(o => o.Payment).ToList();
        }

        public List<Order> GetAllOrderType_1()
        {
            return _context.Orders.Include(o => o.User).Include(o => o.Payment).Where(o => o.Status == "Đang xử lí").ToList();
        }

        public List<Order> GetAllOrderType_2()
        {
            return _context.Orders.Include(o => o.User).Include(o => o.Payment).Where(o => o.Status == "Đang giao hàng").ToList();
        }

        public List<Order> GetAllOrderType_3()
        {
            return _context.Orders.Include(o => o.User).Include(o => o.Payment).Where(o => o.Status == "Đã giao hàng").ToList();
        }

        public List<Order> GetAllOrderType_4()
        {
            return _context.Orders.Include(o => o.User).Include(o => o.Payment).Where(o => o.Status == "Đã hủy").ToList();
        }

        public Order FindOrderById(int id)
        {
            return _context.Orders.Find(id);
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrder(Order order)
        {
            try
            {
                _context.Remove(order);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Order> ShowAllOrderForUser(int id)
        {
            return _context.Orders
                .Include(o => o.User)
                .Include(o => o.Payment)
                .Where(o => o.UserId == id)
                .ToList();
        }

        public List<Order> GetAllOrderForUserType_1(int id)
        {
            return _context.Orders
                .Include(o => o.User)
                .Include(o => o.Payment)
                .Where(o => o.Status == "Đang xử lí" && o.UserId == id)
                .ToList();
        }

        public List<Order> GetAllOrderForUserType_2(int id)
        {
            return _context.Orders
                .Include(o => o.User)
                .Include(o => o.Payment)
                .Where(o => o.Status == "Đang giao hàng" && o.UserId == id)
                .ToList();
        }

        public List<Order> GetAllOrderForUserType_3(int id)
        {
            return _context.Orders
                .Include(o => o.User)
                .Include(o => o.Payment)
                .Where(o => o.Status == "Đã giao hàng" && o.UserId == id)
                .ToList();
        }

        public List<Order> GetAllOrderForUserType_4(int id)
        {
            return _context.Orders
                .Include(o => o.User)
                .Include(o => o.Payment)
                .Where(o => o.Status == "Đã hủy" && o.UserId == id)
                .ToList();
        }
    }
}
