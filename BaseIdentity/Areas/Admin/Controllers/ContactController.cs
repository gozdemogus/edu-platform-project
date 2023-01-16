using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using DTOLayer.DTOs.ContactDTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var values = _mapper.Map<List<ListContactDTO>>(_contactService.TGetList());
            return View(values);
        }

        public IActionResult GetById(int id)
        {
            var values = _mapper.Map<GetByIdContactDTO>(_contactService.TGetById(id));
            return View(values);
        }

        public IActionResult Delete(int id)
        {
           Contact contact = _contactService.TGetById(id);
            _contactService.TDelete(contact);

            var url = Url.RouteUrl("areas", new { controller = "Contact", action = "Index", area = "Admin" });
            return Redirect(url);
        }
    }
}

