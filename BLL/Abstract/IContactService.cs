using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IContactService
    {
        List<ComplaintSuggestion> GetList();
        public void ContactAdd(ComplaintSuggestion c);
    }
}
