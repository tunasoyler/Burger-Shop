using Entity.Concrete;
using MVC.Models.Context;
using NuGet.Common;
using System.Collections;

namespace MVC.Models
{
    public class CartDTO 
    {
        public ICollection<CartItemDTO> CartItems { get; set; }
        public bool State { get; set; }
        public AppUser AppUser { get; set; }
        public Guid AppUserId { get; set; }

        public CartDTO()
        {
            CartItems = new HashSet<CartItemDTO>();
        }
    }

 
}
