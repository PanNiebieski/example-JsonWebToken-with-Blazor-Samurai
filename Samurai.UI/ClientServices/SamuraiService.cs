using AutoMapper;
using Samurai.UI.Interfaces;
using Samurai.UI.Interfaces.Security;
using Samurai.UI.Services;
using Samurai.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samurai.UI.ClientServices
{
    public class SamuraiService : ISamuraiService
    {
        private readonly IMapper _mapper;
        private IClient _client;
        private IAddBearerTokenService _addBearerTokenService;

        public SamuraiService(IClient client, IMapper mapper,
            IAddBearerTokenService addBearerTokenService)
        {
            _mapper = mapper;
            _client = client;
            _addBearerTokenService = addBearerTokenService;
        }

        public async Task<List<WarriorViewModel>> GetAllWarriors()
        {
            await _addBearerTokenService.AddBearerToken(_client);

            try
            {
                var allPosts = await _client.GetAllSamuraisAsync();
                var mappedPosts = _mapper.Map<ICollection<WarriorViewModel>>(allPosts);
                return mappedPosts.ToList();
            }
            catch (ApiException ex)
            {
                return new List<WarriorViewModel>();
            }
        }
    }
}
