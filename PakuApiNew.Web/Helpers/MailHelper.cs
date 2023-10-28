using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using PakuApiNew.Helpers;
using PakuApiNew.Web.Models;
using System;


namespace UbicApi.Web.Helpers
{
    public class MailHelper : IMailHelper
    {
        private readonly IConfiguration _configuration;

        public MailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Response SendMail(string fromR, string smtpR, string portR, string passwordR, string toR, string subjectR, string bodyR)
        {
            try
            {
                string from = fromR;
                string smtp = smtpR;
                string port = portR;
                string password = passwordR;

                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(from));
                message.To.Add(new MailboxAddress(toR));
                message.Subject = subjectR;
                BodyBuilder bodyBuilder = new BodyBuilder
                {
                    HtmlBody = bodyR
                };
                message.Body = bodyBuilder.ToMessageBody();

                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect(smtp, int.Parse(port), false);
                    client.Authenticate(from, password);
                    client.Send(message);
                    client.Disconnect(true);
                }

                return new Response { IsSuccess = true };

            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = ex
                };
            }
        }
    }
}
