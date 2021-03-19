
using Samurai.Application.Security.Contracts;
using Samurai.Application.Security.Models;
using Samurai.Infrastructure.Security.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Infrastructure.Security.Manager
{
    public class SignInManager : ISignInManager<MyUser>
    {
        public Task<SignInResult> PasswordSignInAsync
            (string userName, string password, bool isPersistent,
            bool lockoutOnFailure)
        {
            if (password == "12345")
            {
                return Task.FromResult(SignInResult.Success);
            }
            else
            {
                return Task.FromResult(SignInResult.Fail);
            }

        }
    }
}
