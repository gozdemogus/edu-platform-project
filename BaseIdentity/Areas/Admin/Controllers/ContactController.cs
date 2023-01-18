using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.Excel;
using DTOLayer.DTOs.ContactDTO;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseIdentity.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public ContactController(IContactService contactService, IMapper mapper, IConfiguration configuration)
        {
            _contactService = contactService;
            _mapper = mapper;
            _configuration = configuration;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var values = _mapper.Map<List<ListContactDTO>>(_contactService.TGetList().OrderByDescending(x=>x.Date));
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

        [HttpPost]
        public void SendMail(string message, string MailReceiver, int messageId)
        {
            string mailKey = _configuration["MailKey"];

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "goezdem6@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MimeKit.MailboxAddress mailboxAddressTo = new MailboxAddress("User", MailReceiver);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = message;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Edumy - Response To Your Contact Message";

            SmtpClient smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("goezdem6@gmail.com", mailKey); //kod
            smtp.Send(mimeMessage);
            smtp.Disconnect(true);

            var values = _contactService.TGetById(messageId);
            values.Responsed = true;
            _contactService.TUpdate(values);
        }
    }
}

