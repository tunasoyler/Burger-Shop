using MVC.Models.Context;

namespace MVC.Models
{
    public class UserVM
    {
        public List<AppUser>? UserList { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; } = true;
    }
}
