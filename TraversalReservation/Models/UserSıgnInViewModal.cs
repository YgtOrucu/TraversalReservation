using System.ComponentModel.DataAnnotations;

namespace TraversalReservation.Models
{
    public class UserSıgnInViewModal
    {
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz")]
        public string Password { get; set; }

    }
}
