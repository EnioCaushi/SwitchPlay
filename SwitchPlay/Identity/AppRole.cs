using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwitchPlay.Identity
{
    public class AppRole : IdentityRole
    {
        [NotMapped]
        public bool IsSelected { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
