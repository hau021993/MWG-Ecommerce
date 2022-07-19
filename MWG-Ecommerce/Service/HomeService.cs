using MWG_Ecommerce.Data;
using MWG_Ecommerce.DTO;
using MWG_Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MWG_Ecommerce.Service
{
    public class HomeService
    {
        private readonly ShoppingonlineContext _context;

        public HomeService(ShoppingonlineContext context)
        {
            _context = context;
        }


    }
}
