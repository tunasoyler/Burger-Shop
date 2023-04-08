using Entity.Concrete;

namespace MVC.Models
{
    public class OrderDto
    {
        //<td>@item.Id</td>
        //       <td>@item.AppUser.FirstName</td>
        //       <td>@item.AppUser.LastName</td>
        //       <td>@item.CreatedTime</td>
        //       <td>@item.State</td>
        //       <td>@item.Coupon.Name</td>
        //       <td>@item.OrderTotal</td>
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool State { get; set; }
        public string CouponName { get; set; }
        public decimal OrderTotal { get; set; }
        public Menu menu { get; set; }
        public Extra extra { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
