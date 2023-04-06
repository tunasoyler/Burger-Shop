using MVC.Models.Context;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class UserVM
    {
        public List<AppUser>? UserList { get; set; }

        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        [DataType(DataType.Password,ErrorMessage ="Parolanız gereken değerleri taşımıyor.")]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "Hatalı eposta.")]
        [Required(ErrorMessage = "Lütfen E-mailinizi giriniz.")]
        public string Email { get; set; }
        public bool Status { get; set; } = true;
        public string? NewPassword { get; set; }
    }
}
