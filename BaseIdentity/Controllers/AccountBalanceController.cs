using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract.AbstractUOW;
using BaseIdentity.EntityLayer.Concrete;
using BaseIdentity.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Controllers
{
    public class AccountBalanceController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAccountService _accountService;
        private readonly RoleManager<AppRole> _roleManager;


        public AccountBalanceController(IAccountService accountService, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> DoPayment(decimal total)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueSender = _accountService.TGetByID(user.Id);
            var superAdmin = await _userManager.GetUsersInRoleAsync("SuperAdmin");
            var valueReceiver = _accountService.TGetByID(superAdmin.FirstOrDefault().Id);

            valueSender.Balance -= total;
            valueReceiver.Balance += total;

            List<Account> modifiedAccounts = new List<Account>()
            {
                valueSender,
                valueReceiver
            };

            _accountService.TMultiUpdate(modifiedAccounts);

            return RedirectToAction("Enroll", "Enrollment");
        }
    }
}

