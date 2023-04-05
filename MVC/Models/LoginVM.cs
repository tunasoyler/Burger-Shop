namespace MVC.Models
{
    public class LoginVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
