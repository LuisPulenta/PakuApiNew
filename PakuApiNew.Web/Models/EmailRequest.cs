namespace PakuApiNew.Web.Models
{
    public class EmailRequest
    {
        public string From { get; set; }
        public string Smtp { get; set; }
        public string Port { get; set; }
        public string Password { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
