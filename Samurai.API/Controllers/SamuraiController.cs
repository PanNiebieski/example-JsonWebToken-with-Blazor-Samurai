using Microsoft.AspNetCore.Mvc;
using Samurai.Application.Contracts;
using Samurai.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samurai.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraiController : Controller
    {
        public ISamuraiWarriorRepository _warriorRepository;

        public SamuraiController(ISamuraiWarriorRepository warriorRepository)
        {
            _warriorRepository = warriorRepository;
        }


        [HttpGet(Name = "GetAllSamurais")]
        public async Task<ActionResult<List<Warrior>>> GetAllPosts()
        {
            var list = await _warriorRepository.GetAllAsync();
            return list;
        }
    }
}
