using Samurai.Application.Contracts;
using Samurai.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samurai.Infrastructur.Persistence.StaticClass
{
    public class SamuraiWarriorRepository : ISamuraiWarriorRepository
    {



        public Task<List<Warrior>> GetAllAsync()
        {
            List<Warrior> list = new List<Warrior>();

            list.Add(new Warrior()
            {
                Age = 32,
                Name = "Yukidoh Saturo",
                ImageUrl =
                @"https://pl.wikiquote.org/wiki/Samuraj#/media/Plik:Samurai_in_gala_costume.jpg"
            });

            list.Add(new Warrior()
            {
                Age = 21,
                Name = "Kat"
            ,
                ImageUrl =
                @"https://static.wikia.nocookie.net/aegaris/images/0/0e/Samurai.jpg/revision/latest/scale-to-width-down/411?cb=20200123154415&path-prefix=pl"
            });

            return Task.FromResult(list);
        }
    }
}
