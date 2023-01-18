using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.BusinessLayer.ValidationRules.UserValidation;
using BaseIdentity.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, UserManager<AppUser> userManager)
        {
            _contactService = contactService;
            _userManager = userManager;
        }


        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
           
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                Contact contact = new Contact();
                contact.Name = user.Name;
                contact.Email = user.Email;
                contact.UserName = user.UserName;
                return View(contact);

            }
            return View();
           
        }

        [HttpPost]
        public async Task<IActionResult> Index(Contact contact)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                contact.Name = user.Name;
                contact.Email = user.Email;
                contact.UserName = user.UserName;
            }
            contact.Date = DateTime.Now;
            contact.Responsed = false;
            //VALIDATION
            AddContactValidator validationRules = new AddContactValidator();
            ValidationResult result = validationRules.Validate(contact);

            if (result.IsValid)
            {
                _contactService.TInsert(contact);
                TempData["SuccessMessage"] = "Your message has been sent successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(contact);
            }
        }

    }
}

