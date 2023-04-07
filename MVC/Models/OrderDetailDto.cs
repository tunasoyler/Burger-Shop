namespace MVC.Models
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public byte[]? MenuImage { get; set; }
        public string MenuName { get; set; }
        public byte[]? ExtraImage { get; set; }
        public string ExtraName { get; set; }
        public bool Status { get; set; }
        public DateTime ModifiedTime { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
