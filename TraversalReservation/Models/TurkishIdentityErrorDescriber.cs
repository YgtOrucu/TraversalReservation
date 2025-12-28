using Microsoft.AspNetCore.Identity;

public class TurkishIdentityErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError PasswordTooShort(int length)
        => new IdentityError
        {
            Code = nameof(PasswordTooShort),
            Description = $"Şifre en az {length} karakter olmalıdır."
        };

    public override IdentityError PasswordRequiresUpper()
        => new IdentityError
        {
            Code = nameof(PasswordRequiresUpper),
            Description = "Şifre en az bir büyük harf içermelidir."
        };

    public override IdentityError PasswordRequiresLower()
        => new IdentityError
        {
            Code = nameof(PasswordRequiresLower),
            Description = "Şifre en az bir küçük harf içermelidir."
        };

    public override IdentityError PasswordRequiresDigit()
        => new IdentityError
        {
            Code = nameof(PasswordRequiresDigit),
            Description = "Şifre en az bir rakam içermelidir."
        };  
}
