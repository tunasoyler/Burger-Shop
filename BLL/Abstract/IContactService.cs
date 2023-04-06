using DAL.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
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
        public ComplaintSuggestion FindById(int id);
        public bool ContactRemove(ComplaintSuggestion c);
    }
}
