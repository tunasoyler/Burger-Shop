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
        IComplaintSuggestion _complaintSuggestion;

        public ContactManager(IComplaintSuggestion complaintSuggestion)
        {
            _complaintSuggestion = complaintSuggestion;
        }

        public void AddMessage(ComplaintSuggestion message)
        {
            _complaintSuggestion.Insert(message);
        }
    }
}
