using Microsoft.EntityFrameworkCore;
using SwitchPlay.Data;
using SwitchPlay.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPlay.Identity
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SwitchPlayContext context;
        public RoleRepository(SwitchPlayContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<AppRole> FindAll()
        {
            return context.Roles;
        }

        public async Task<IEnumerable<AppRole>> FindAllAsync()
        {
            return await context.Roles.ToListAsync();
        }

        public async Task CreateRoleAsync(AppRole role)
        {
            await context.Roles.AddAsync(role);
            await context.SaveChangesAsync();
        }
    }
}
