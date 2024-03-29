﻿using Samurai.Application.Security.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Application.Security.Contracts
{
    public interface IUserManager<TUser> where TUser : class
    {
        Task<List<string>> GetRolesAsync(TUser user);
        Task<List<Claim>> GetClaimsAsync(TUser user);
        Task<TUser> FindByEmailAsync(string email);
        Task<TUser> FindByNameAsync(string userName);
        Task<UserManagerResult> CreateAsync(TUser user, string password);
    }
}
