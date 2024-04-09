using SwitchPlay.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPlay.Identity
{
  public  interface IRoleRepository
    {
        IEnumerable<AppRole> FindAll();
        Task<IEnumerable<AppRole>> FindAllAsync();
        Task CreateRoleAsync(AppRole role);
    }
}
