using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class LoginVM
    {
        [EmailAddress(ErrorMessage = "Hatalı eposta.")]
        [Required(ErrorMessage = "Lütfen E-mailinizi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        [DataType(DataType.Password, ErrorMessage = "Parolanız gereken değerleri taşımıyor.")]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
        public bool Remember { get; set; }
    }
}
