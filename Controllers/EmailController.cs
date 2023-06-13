
using Microsoft.AspNetCore.Mvc;
using MiniHospitalProject.Models;
using MiniHospitalProject.Services;

namespace MiniHospitalProject.Controllers
{
    public class EmailController : Controller
    {
        private readonly IMailService _service;
        public EmailController(IMailService service)
        {
            _service = service;
        }
        public IActionResult Send()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Send(MailContent mail)
        {
            _service.SendEmail(mail);
            return View();
        }
    }
}
