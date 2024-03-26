using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPlay.Identity
{
   public interface IRoleService
    {
        IEnumerable<AppRole> GetRoles();
        Task<IEnumerable<AppRole>> GetRolesAsync();
    }
}
