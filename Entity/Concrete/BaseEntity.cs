using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime ModifiedTime { get; set; } = DateTime.Now;
        public bool State { get; set; }
    }
}
