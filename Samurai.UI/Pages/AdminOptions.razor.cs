using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.UI.Pages
{
    public partial class AdminOptions
    {
        [Inject]
        public AuthenticationStateProvider _authenticationStateProvider { get; set; }

        [Inject]
        protected ILocalStorageService _localStorage { get; set; }

        public AdminOptions()
        {

        }

        [Parameter]
        public MarkupString Data { get; set; } = new MarkupString("");

        protected async override Task OnInitializedAsync()
        {
            var use = (await _authenticationStateProvider.GetAuthenticationStateAsync());

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(use.User.Identity.Name);
            sb.Append("<br />");

            sb.AppendLine(" <ul> ");
            foreach (var item in use.User.Claims)
            {
                sb.Append(" <li> ");
                sb.Append(" <ol> ");
                sb.Append(" <li> ");
                sb.AppendLine(item.Type);
                sb.Append(" </li> ");
                sb.Append(" <li> ");
                sb.AppendLine(item.Value);
                sb.Append(" </li> ");
                sb.Append(" </ol> ");
                sb.Append(" </li> ");
            }
            sb.AppendLine(" </ul> ");
            sb.Append("<br /> Jest Adminiem");
            sb.AppendLine(use.User.IsInRole("Admin").ToString());
            sb.Append("<br /> Ma MyValue");
            sb.AppendLine(use.User.Claims.Any(p => p.Value == "MyValue").ToString());
            sb.Append("<br /> Ma Cos");
            sb.AppendLine(use.User.Claims.Any(p => p.Type == "MyCos").ToString());


            Data = new MarkupString(sb.ToString());
        }


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected void DeleteToken()
        {
            _localStorage.RemoveItemAsync("token");
            NavigationManager.NavigateTo("/");
        }

        protected void NavigateToList()
        {
            NavigationManager.NavigateTo("/samurailist");
        }

    }
}
