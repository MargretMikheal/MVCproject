using Microsoft.AspNetCore.Identity;

namespace MVCproject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }

        public byte[]? ProfilePicture { get; set; }
        //public string ProfilePicture { get; set; } = "/images/default-profile.png"; // Default picture
        public ICollection<Order> Orders { get; set; }
        public Cart Cart { get; set; }
    }

}
