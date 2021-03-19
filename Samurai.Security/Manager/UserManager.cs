using Samurai.Application.Security.Contracts;
using Samurai.Application.Security.Models;
using Samurai.Infrastructure.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Infrastructure.Security.Manager
{
    public class UserManager : IUserManager<MyUser>
    {
        public Task<MyUser> FindByEmailAsync(string email)
        {
            string tolower = email.ToLowerInvariant();
            var user = StaticUserList.Users().FirstOrDefault
                (p => p.Email.ToLowerInvariant() == tolower);

            return Task.FromResult(user);
        }

        public Task<MyUser> FindByNameAsync(string userName)
        {
            string tolower = userName.ToLowerInvariant();
            var user = StaticUserList.Users().FirstOrDefault
                (p => p.UserName.ToLowerInvariant() == tolower);

            return Task.FromResult(user);
        }

        public Task<List<Claim>> GetClaimsAsync(MyUser user)
        {
            Claim c = new Claim("MyCos", "MyValue");
            var lis = new List<Claim>();
            lis.Add(c);
            return Task.FromResult(lis);
        }

        public Task<List<string>> GetRolesAsync(MyUser user)
        {
            string c = "User";
            var lis = new List<string>();
            lis.Add(c);
            return Task.FromResult(lis);
        }

        public Task<UserManagerResult> CreateAsync(MyUser user, string password)
        {
            StaticUserList.Users().Add(user);

            return Task.FromResult(UserManagerResult.Success);
        }
    }
}
