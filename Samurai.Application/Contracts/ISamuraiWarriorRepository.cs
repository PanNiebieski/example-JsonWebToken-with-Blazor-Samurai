using Samurai.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Application.Contracts
{
    public interface ISamuraiWarriorRepository
    {
        Task<List<Warrior>> GetAllAsync();
    }
}
