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
    public class AccountManagerController : Controller
    {
        private readonly ILogger<AccountManagerController> _logger;
        private readonly ShoppingonlineContext _context;
        private readonly AccountService accountService;
        private readonly LoginHistoryService loginHistoryService;

        public AccountManagerController(ILogger<AccountManagerController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            accountService = new AccountService(context);
            loginHistoryService = new LoginHistoryService(context);
        }

        public IActionResult Index()
        {
            ViewData["Account"] = "active";
            return View("/Views/Admin/Account/AccountManager.cshtml", accountService.GetAllAccount());
        }

        public IActionResult ShowUser()
        {
            //ViewData["Account"] = "active";
            return View("/Views/Admin/Account/AccountManager.cshtml", accountService.GetAllUser());
        }

        public IActionResult ShowAdmin()
        {
            //ViewData["Account"] = "active";
            return View("/Views/Admin/Account/AccountManager.cshtml", accountService.GetAllAdmin());
        }

        public ActionResult AddAccount(int id = 0)
        {
            if (id == 0)
            {
                return View("/Views/Admin/Account/AddAccount.cshtml", new User());
            }
            else
            {
                var account = accountService.FindUserById(id);
                if (account == null)
                {
                    return NotFound();
                }
                return View("/Views/Admin/Account/AccountDetail.cshtml", account);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAccount(int id, User account)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await accountService.AddUser(account);
                }
                else
                {
                    try
                    {
                        //await accountService.UpdateUser(account);                      

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (accountService.FindUserById(id) == null)
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Ok("Thêm thành công!");
            }
            else
            {
                return View("/Views/Admin/Account/AddAccount.cshtml", account);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var account = accountService.FindUserById(id);
            bool isDelete = await accountService.DeleteUser(account);
            if (isDelete)
            {
                return Ok("Xóa đối tượng thành công!");
            }
            else
            {
                return BadRequest("Xóa đối tượng thất bại!");
            }
        }

        public IActionResult AccountLoginHistory(int id)
        {
            var account = accountService.FindUserById(id);
            loginHistoryService.GetAllLoginHistoryByIdUser(id);
            return View("/Views/Admin/Account/AccountLoginHistory.cshtml", account);
        }

        public IActionResult MyAccountLoginHistory(int idSession)
        {
            ViewData["CategoryList"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierList"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            idSession = (int)HttpContext.Session.GetInt32("id");
            var account = accountService.FindUserById(idSession);
            loginHistoryService.GetAllLoginHistoryByIdUser(idSession);
            return View("/Views/Admin/Account/MyAccountLoginHistory.cshtml", account);
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMyLoginHistory(int id)
        {          
            var loginHistory = loginHistoryService.FindLoginHistoryById(id);
            bool isDelete = await loginHistoryService.DeleteMyLoginHistory(loginHistory);
            if (isDelete)
            {
                return Ok("Xóa đối tượng thành công!");
            }
            else
            {
                return BadRequest("Xóa đối tượng thất bại!");
            }
        }

        public ActionResult MyInfoDetail(int idSession)
        {
            ViewData["CategoryList"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierList"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            idSession = (int)HttpContext.Session.GetInt32("id");
            var account = accountService.FindUserById(idSession);
            if (account == null)
            {
                return NotFound();
            }
            return View("/Views/Admin/Account/MyInfoDetail.cshtml", account);           
        }

        public ActionResult EditMyInfo(int idSession)
        {
            idSession = (int)HttpContext.Session.GetInt32("id");
            var account = accountService.FindUserById(idSession);
            if (account == null)
            {
                return NotFound();
            }
            return View("/Views/Admin/Account/EditMyInfo.cshtml", account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMyInfo(int idSession, User account)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await accountService.UpdateUser(account);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (accountService.FindUserById(idSession) == null)
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
                return View("/Views/Admin/Account/EditMyInfo.cshtml", account);
            }
        }       

    }
}
