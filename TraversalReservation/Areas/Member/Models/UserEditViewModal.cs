namespace TraversalReservation.Areas.Member.Models
{
    public class UserEditViewModal
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string ImgUrl { get; set; }
        public IFormFile Image { get; set; }

    }
}
