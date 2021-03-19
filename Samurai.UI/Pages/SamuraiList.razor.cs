using Microsoft.AspNetCore.Components;
using Samurai.UI.Interfaces;
using Samurai.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samurai.UI.Pages
{
    public partial class SamuraiList
    {
        [Inject]
        public ISamuraiService SamuraiService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<WarriorViewModel> Warriors { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Warriors = await SamuraiService.GetAllWarriors();
        }


    }
}
