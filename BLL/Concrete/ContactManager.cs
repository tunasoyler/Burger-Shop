using BLL.Abstract;
using DAL.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
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



        public bool ContactAdd(ComplaintSuggestion c)
        {
            bool IsTrue = _s.Insert(c);
            return IsTrue;
        }

        public bool ContactRemove(ComplaintSuggestion c)
        {
           bool IsTrue=_s.Delete(c);
            return IsTrue;
        }

        public bool ContactUpdate(ComplaintSuggestion c)
        {
            bool IsTrue = _s.Update(c);
            return IsTrue;
        }

        public ComplaintSuggestion FindById(int id)
        {
           return _s.Find(id);
        }

        public List<ComplaintSuggestion> GetList()
        {
            return _s.List();
        }




    }
}
