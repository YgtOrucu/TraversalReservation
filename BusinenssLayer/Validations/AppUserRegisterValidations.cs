using DTOLayers.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinenssLayer.Validations
{
    public class AppUserRegisterValidations : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidations()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationsRules.NotEmpty("İsim")).
                MaximumLength(25).WithMessage(ValidationsRules.MaxLength(25, "İsim")).
                MinimumLength(3).WithMessage(ValidationsRules.MinLength(3, "İsim")).
                Matches(ValidationsRules.OnlyLettersWithSpace).WithMessage(ValidationsRules.OnlyLetters("İsim"));

            RuleFor(x => x.Surname).NotEmpty().WithMessage(ValidationsRules.NotEmpty("Soyadı")).
                MaximumLength(25).WithMessage(ValidationsRules.MaxLength(25, "Soyadı")).
                MinimumLength(3).WithMessage(ValidationsRules.MinLength(3, "Soyadı")).
                Matches(ValidationsRules.OnlyLettersWithSpace).WithMessage(ValidationsRules.OnlyLetters("Soyadı"));

            RuleFor(x => x.Username).NotEmpty().WithMessage(ValidationsRules.NotEmpty("Kullanıcı Adı")).
                MaximumLength(25).WithMessage(ValidationsRules.MaxLength(25, "Kullanıcı Adı")).
                MinimumLength(3).WithMessage(ValidationsRules.MinLength(3, "Kullanıcı Adı"));

            RuleFor(x => x.Phone).NotEmpty().WithMessage(ValidationsRules.NotEmpty("Telefon")).
                MaximumLength(11).WithMessage(ValidationsRules.MaxLength(25, "Telefon")).
                Matches(ValidationsRules.OnlyNumberss).WithMessage(ValidationsRules.OnlyNumbers("Telefon"));

            RuleFor(x => x.Mail).NotEmpty().WithMessage(ValidationsRules.NotEmpty("Mail")).
                Matches(ValidationsRules.Email).WithMessage("Mailinizi kontrol ediniz.");

            RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationsRules.NotEmpty("Şifre")).
                MaximumLength(25).WithMessage(ValidationsRules.MaxLength(25, "Şifre")).
                MinimumLength(3).WithMessage(ValidationsRules.MinLength(3, "Şifre"));

            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Şifreler birbiri ile uyuşmuyor");
        }
    }
}
