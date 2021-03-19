using AutoMapper;
using Samurai.UI.Services;
using Samurai.UI.ViewModels;

namespace Samurai.UI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WarriorViewModel, Warrior>().ReverseMap();

        }
    }
}
