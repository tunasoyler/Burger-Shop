using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validations
{
    public class ContactValidator : AbstractValidator<ComplaintSuggestion>
    {
        public ContactValidator()
        {
            //RuleFor(x=> )
        }
    }
}
