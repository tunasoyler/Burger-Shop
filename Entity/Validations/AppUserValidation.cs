using System.ComponentModel.DataAnnotations;

namespace Entity.Validations
{
    public class AppUserValidation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Lütfen adınızı giriniz")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz")]
        public string LastName { get; set; }
    }
}