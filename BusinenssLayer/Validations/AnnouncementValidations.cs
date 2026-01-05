using DTOLayers.DTOs.AnnouncementDTOs;
using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinenssLayer.Validations
{
    public class AnnouncementValidations : AbstractValidator<AnnouncementDTO>
    {
        public AnnouncementValidations()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(ValidationsRules.NotEmpty("Title"))
               .MaximumLength(25).WithMessage(ValidationsRules.MaxLength(25, "Title"))
               .MinimumLength(5).WithMessage(ValidationsRules.MinLength(5, "Title"))
               .Matches(ValidationsRules.OnlyLettersWithSpace).WithMessage(ValidationsRules.OnlyLetters("Title"));

            RuleFor(x => x.Content).NotEmpty().WithMessage(ValidationsRules.NotEmpty("Content"))
               .MaximumLength(500).WithMessage(ValidationsRules.MaxLength(500, "Content"))
               .MinimumLength(10).WithMessage(ValidationsRules.MinLength(10, "Content"))
               .Matches(ValidationsRules.OnlyLettersWithSpace).WithMessage(ValidationsRules.OnlyLetters("Content"));
        }
    }
}
