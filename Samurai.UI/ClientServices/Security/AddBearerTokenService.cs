using Blazored.LocalStorage;
using Samurai.UI.Interfaces.Security;
using Samurai.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Samurai.UI.ClientServices.Security
{
    public class AddBearerTokenService : IAddBearerTokenService
    {
        private readonly ILocalStorageService _localStorage;


        public AddBearerTokenService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;

        }

        public async Task AddBearerToken(IClient client)
        {
            if (await _localStorage.ContainKeyAsync("token"))
                client.HttpClient.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
        }
    }
}
