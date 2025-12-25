using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinenssLayer.Validations
{
    public class AboutValidations : AbstractValidator<About>
    {
        string onlylatters = "^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$";
        //string onlymail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        //string onlynumber = @"^[0-9]+$";
        public AboutValidations()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(ValidationsRules.NotEmpty("About"))
                .MaximumLength(25).WithMessage(ValidationsRules.MaxLength(25, "About"))
                .MinimumLength(5).WithMessage(ValidationsRules.MinLength(5, "About"))
                .Matches(onlylatters).WithMessage(ValidationsRules.OnlyLetters("About"));
        }
    }
}
