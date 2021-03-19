using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Samurai.UI.ClientServices;
using Samurai.UI.ClientServices.Security;
using Samurai.UI.Interfaces;
using Samurai.UI.Interfaces.Security;
using Samurai.UI.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001")
            });

            builder.Services.AddHttpClient<IClient, Client>
                (client => client.BaseAddress = new Uri("https://localhost:5001"));

            builder.Services.AddScoped<ISamuraiService, SamuraiService>();

            //Auth
            builder.Services.AddScoped<IBlazorAuthenticationService,
                BlazorAuthenticationService>();
            builder.Services.AddScoped<AuthenticationStateProvider,
                CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<IAddBearerTokenService,
                AddBearerTokenService>();

            builder.Services.AddAuthorizationCore(config =>
            {
                config.AddPolicy(Policies.IsAdmin, Policies.IsUserLogged());
                config.AddPolicy(Policies.IsUserLog, Policies.IsUserLogged());
                config.AddPolicy(Policies.IsUser, Policies.IsUserPolicy());
                config.AddPolicy(Policies.IsClaim, Policies.IsClaimed());
            });

            await builder.Build().RunAsync();
        }
    }

    public static class Policies
    {
        public const string IsAdmin = "IsAdmin";
        public const string IsUserLog = "IsUserLog";
        public const string IsUser = "IsUser";
        public const string IsClaim = "IsClaim";

        public static AuthorizationPolicy IsAdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()

                                                   .RequireRole("adminEdu")
                                                   .Build();
        }

        public static AuthorizationPolicy IsUserLogged()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()

                                                   .Build();
        }

        public static AuthorizationPolicy IsClaimed()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                .RequireClaim("MyCos", "MyValue")
                .Build();
        }

        public static AuthorizationPolicy IsUserPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                   .RequireRole("User")
                                                   .Build();
        }
    }
}
