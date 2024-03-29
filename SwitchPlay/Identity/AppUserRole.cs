﻿using Microsoft.AspNetCore.Identity;

namespace SwitchPlay.Identity
{
    public class AppUserRole : IdentityUserRole<string>
    {
        public virtual AppUser User { get; set; }
        public virtual AppRole Role { get; set; }
    }
  
}
