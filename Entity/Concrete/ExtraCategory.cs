using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class ExtraCategory : BaseEntity
    {
        public ICollection<Extra> Extras { get; set; }
        public string? Description { get; set; }
        public ExtraCategory()
        {
            Extras = new HashSet<Extra>();
        }

    }
}
