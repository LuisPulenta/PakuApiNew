using PakuApiNew.Web.Models;

namespace PakuApiNew.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string fromR, string smtpR, string portR, string passwordR, string toR, string subjectR, string bodyR);
    }
}
