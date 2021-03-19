

using Samurai.Application.Security.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Application.Security.Contracts
{
    public interface ISignInManager<TUser> where TUser : class
    {
        Task<SignInResult> PasswordSignInAsync
            (string userName, string password,
            bool isPersistent, bool lockoutOnFailure);
    }
}
