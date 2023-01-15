using System;
using System.Threading.Tasks;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.BusinessLayer.Abstract.AbstractUOW;
using BaseIdentity.EntityLayer.Concrete;
using BaseIdentity.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaseIdentity.PresentationLayer.ViewComponents
{
	public class Payment:ViewComponent
	{
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;


        public Payment(IAccountService accountService, UserManager<AppUser> userManager)
        {
            _accountService = accountService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueSender = _accountService.TGetByID(user.Id);

            ViewBag.balance = valueSender.Balance;
            AccountBalanceViewModel accountBalanceViewModel = new AccountBalanceViewModel();

            return View(accountBalanceViewModel);
        }
    }
}

