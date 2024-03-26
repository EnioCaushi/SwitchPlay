﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPlay.Identity
{
   public class RoleService : IRoleService
    {
        public readonly IRoleRepository context;
        public RoleService(IRoleRepository repository)
        {
            context = repository;
        }

        public IEnumerable<AppRole> GetRoles()
        {
            return context.FindAll();
        }

        public Task<IEnumerable<AppRole>> GetRolesAsync()
        {
            return context.FindAllAsync();
        }
    }
}
