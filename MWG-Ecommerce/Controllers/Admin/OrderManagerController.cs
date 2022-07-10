using MWG_Ecommerce.DTO;
using MWG_Ecommerce.Data;
using MWG_Ecommerce.Models;
using MWG_Ecommerce.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MWG_Ecommerce.Controllers.Admin
{
    public class OrderManagerController : Controller
    {
        private readonly ILogger<DiscountManagerController> _logger;
        private readonly ShoppingonlineContext _context;
        private readonly OrderService orderService;
        private readonly OrderDetailService orderDetailService;

        public OrderManagerController(ILogger<DiscountManagerController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            orderService = new OrderService(context);
            orderDetailService = new OrderDetailService(context);
        }

        public IActionResult Index()
        {
            ViewData["Order"] = "active";
            return View("/Views/Admin/Order/OrderManager.cshtml", orderService.GetAllOrder());         
        }

        public IActionResult ShowOrderType_1()
        {           
            return View("/Views/Admin/Order/OrderManager.cshtml", orderService.GetAllOrderType_1());
        }

        public IActionResult ShowOrderType_2()
        {
            return View("/Views/Admin/Order/OrderManager.cshtml", orderService.GetAllOrderType_2());
        }

        public IActionResult ShowOrderType_3()
        {
            return View("/Views/Admin/Order/OrderManager.cshtml", orderService.GetAllOrderType_3());
        }

        public IActionResult ShowOrderType_4()
        {
            return View("/Views/Admin/Order/OrderManager.cshtml", orderService.GetAllOrderType_4());
        }

        public ActionResult EditOrder(int id)
        {
            var order = orderService.FindOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["OrderStatus"] = new SelectList(_context.Orders, "OrderId", "Status");
            return View("/Views/Admin/Order/EditOrder.cshtml", order);           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrder(int id, Order order)
        {
            if (ModelState.IsValid)
            {
               
                try
                {
                    await orderService.UpdateOrder(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (orderService.FindOrderById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            return Ok("Sửa thành công!");
            }
            else
            {
                ViewData["OrderStatus"] = new SelectList(_context.Orders, "OrderId", "Status", order.OrderId);
                return View("/Views/Admin/Order/EditOrder.cshtml", order);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var order = orderService.FindOrderById(id);
            bool isDelete = await orderService.DeleteOrder(order);

            if (isDelete)
            {
                return Ok("Xóa đối tượng thành công!");
            }
            else
            {
                return BadRequest("Xóa đối tượng thất bại!");
            }
        }

        public ActionResult ShowOrderDetail(int id)
        {
            ViewData["TotalMoney"] = orderDetailService.TotalMoney(id);
            var orderDetail = orderService.FindOrderById(id);
            orderDetailService.GetAllOrderDetailByOrder(id);
            if (orderDetail == null)
            {
                return NotFound();
            }          
            return View("/Views/Admin/Order/ShowOrderDetail.cshtml", orderDetail);
        }
    }
}
