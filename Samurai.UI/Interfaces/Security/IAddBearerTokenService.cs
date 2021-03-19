using Samurai.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samurai.UI.Interfaces.Security
{
    public interface IAddBearerTokenService
    {
        Task AddBearerToken(IClient client);
    }
}
