using MiniHospitalProject.Models;

namespace MiniHospitalProject.Services
{
    public interface IMailService
    {
        bool SendEmail(MailContent messagebody);
    }
}
