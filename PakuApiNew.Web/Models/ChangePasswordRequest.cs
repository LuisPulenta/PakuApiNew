using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Models

{
    public class ChangePasswordRequest
    {
        public int IDUser { get; set; }
        public string NewPassword { get; set; }
    }
}
