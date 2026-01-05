using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinenssLayer.Validations
{
    public static class ValidationsRules
    {
        public static string NotEmpty(string name)
             => $"{name} kısmı boş bırakılamaz.Lütfen {name} alanını kontrol ediniz.";

        public static string OnlyLetters(string Matches)
            => $"{Matches} kısmı sadece harflerden oluşmalıdır.";

        public static string OnlyNumbers(string Matches)
           => $"{Matches} kısmı sadece sayılardan oluşmalıdır.";

        public static string MinLength(int length, string name)
            => $"{name} alanı en az {length} karakter olmalıdır.";

        public static string MaxLength(int length, string name)
            => $"{name} alanı en fazla {length} karakter olabilir.";


        public const string OnlyLettersWithSpace = @"^\p{L}+(?:\s+\p{L}+)*$";

        public const string OnlyNumberss = @"^\d+$";

        public const string Email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";


    }
}
