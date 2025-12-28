using System.ComponentModel.DataAnnotations;

namespace TraversalReservation.Models
{
    public class UserRegisterViewModal
    {
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Lütfen bu alanı doldurunuz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        [Compare("Password",ErrorMessage ="Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }
    }
}
