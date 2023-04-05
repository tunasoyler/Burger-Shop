using BLL.Abstract;
using DAL.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class ContactManager : IContactService
    {
        IComplaintSuggestion _s;
        public ContactManager(IComplaintSuggestion s)
        {
            _s = s;
        }



        public void ContactAdd(ComplaintSuggestion c)
        {
            _s.Insert(c);
        }



        public List<ComplaintSuggestion> GetList()
        {
            return _s.List();
        }




    }
}
