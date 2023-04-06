using Entity.Concrete;

namespace MVC.Models
{
    public class ComplaintSuggestionVM
    {
        public List<ComplaintSuggestion> ComplaintSuggestionsList { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
