using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class ResetPasswordModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen mail adresinizi yazınız.")]
        [EmailAddress(ErrorMessage = "Mail adresiniz uygun formatta değil.")]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen şifre girişi yapınız.")]
        [DataType(DataType.Password, ErrorMessage = "Şifreniz uygun formatta değil.")]
        public string NewPassword { get; set; }
    }
}
