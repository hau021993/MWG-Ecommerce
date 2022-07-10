using MWG_Ecommerce.Data;
using MWG_Ecommerce.DTO;
using MWG_Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MWG_Ecommerce.Service
{
    public class ReportService
    {
        private readonly ShoppingonlineContext _context;

        public ReportService(ShoppingonlineContext context)
        {
            _context = context;
        }

        public List<Order> GetAllOrder(DateTime formDate, DateTime toDate)
        {           
            var list = _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .Where(o => o.OrderDate >= formDate && o.OrderDate <= toDate && o.Status == "Đã giao hàng")              
                .ToList();           
            return list;
        }

        public int GetCountOrderByDate(DateTime formDate, DateTime toDate)
        {
            return _context.Orders           
                .Include(o => o.OrderDetails)
                .Where(o => o.OrderDate >= formDate && o.OrderDate <= toDate && o.Status == "Đã giao hàng")
                .Count();               
        }

        public int GetCountUserByDate(DateTime formDate, DateTime toDate)
        {
            var list = _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .Where(o => o.OrderDate >= formDate && o.OrderDate <= toDate && o.Status == "Đã giao hàng")
                .ToList();
            var count = list.Select(o => o.UserId).Distinct().Count();
            return count;
        }

        public int GetTotalMoneyOrderByDate(DateTime formDate, DateTime toDate)
        {
            return _context.OrderDetails       
                .Include(o => o.Order)
                .Where(o => o.Order.OrderDate >= formDate && o.Order.OrderDate <= toDate && o.Order.Status == "Đã giao hàng")
                .Sum(o => o.Total);
        }

        public int GetAllTotalMoney()
        {
            return _context.OrderDetails
                .Include(o => o.Order)
                .Where(o => o.Order.Status == "Đã giao hàng")
                .Sum(o => o.Total);
        }

        public List<OrderDetail> GetAllProduct(DateTime formDate, DateTime toDate)
        {
            var list = _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .Where(o => o.Order.OrderDate >= formDate && o.Order.OrderDate <= toDate && o.Order.Status == "Đã giao hàng")
                .ToList();
            return list;
        }

        public int GetCountProductByDate(DateTime formDate, DateTime toDate)
        {
            var list = _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .Where(o => o.Order.OrderDate >= formDate && o.Order.OrderDate <= toDate && o.Order.Status == "Đã giao hàng")
                .ToList();
            var count = list.Select(o => o.ProductId).Distinct().Count();
            return count;
        }
        
        public int GetSumQuanlityProductByDate(DateTime formDate, DateTime toDate)
        {
            return _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .Where(o => o.Order.OrderDate >= formDate && o.Order.OrderDate <= toDate && o.Order.Status == "Đã giao hàng")
                .Sum(o => o.Quantity);                          
        }

        public int GetAllCountProduct()
        {
            var list = _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .Where(o => o.Order.Status == "Đã giao hàng")
                .ToList();
            var count = list.Select(o => o.ProductId).Distinct().Count();
            return count;
        }

        public int GetAllSumQuanlityProduct()
        {
            return _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .Where(o => o.Order.Status == "Đã giao hàng")
                .Sum(o => o.Quantity);
        }
    }
}
