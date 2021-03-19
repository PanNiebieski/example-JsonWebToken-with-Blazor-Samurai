using Microsoft.AspNetCore.Components;
using Samurai.UI.Interfaces.Security;
using Samurai.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samurai.UI.Pages
{
    public partial class Login
    {
        public LoginBlazorVM LoginViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IBlazorAuthenticationService AuthenticationService { get; set; }

        public Login()
        {

        }

        protected override void OnInitialized()
        {
            LoginViewModel = new LoginBlazorVM();
        }

        protected async void HandleValidSubmit()
        {
            if (await AuthenticationService.Authenticate
                (LoginViewModel.Email, LoginViewModel.Password))
            {
                NavigationManager.NavigateTo("adminoptions");
            }
            Message = "Username/password Coś jest źle";
        }
    }
}
