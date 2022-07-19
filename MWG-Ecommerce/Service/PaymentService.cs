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
    public class PaymentService
    {
        private readonly ShoppingonlineContext _context;

        public PaymentService(ShoppingonlineContext context)
        {
            _context = context;
        }

        public List<Payment> GetAllPayment()
        {
            return _context.Payments.Where(p => p.PaymentStatus == true).ToList();
        }
    }
}
