using Samurai.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samurai.UI.Interfaces
{
    public interface ISamuraiService
    {
        Task<List<WarriorViewModel>> GetAllWarriors();
    }
}
