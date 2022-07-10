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
    public class OrderDetailService
    {
        private readonly ShoppingonlineContext _context;

        public OrderDetailService(ShoppingonlineContext context)
        {
            _context = context;
        }

        public List<OrderDetail> GetAllOrderDetail()
        {
            return _context.OrderDetails.ToList();
        }

        public List<OrderDetail> GetAllOrderDetailByOrder(int? id)
        {
            var list = _context.OrderDetails
                .Include(d => d.Order)
                .Include(d => d.Product)
                .Where(m => m.OrderId == id).ToList();
            return list;
        }

        public List<OrderDetail> FindOrderDetailById(int idor)
        {
            return _context.OrderDetails
                .Include(d => d.Order)
                .Include(d => d.Product)
                .Where(m => m.OrderId == idor).ToList();
        }

        public async Task<bool> DeleteOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _context.Remove(orderDetail);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public int TotalMoney(int id)
        {
            return _context.OrderDetails.Where(o => o.OrderId == id).Sum(o => o.Total);
        }
    }
}
