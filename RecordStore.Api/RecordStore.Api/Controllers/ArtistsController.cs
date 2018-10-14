using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecordStore.DomainObjects;
using RecordStore.Services.Interfaces;

namespace RecordStore.Api.Controllers
{
    [Route("api/artists")]
    public class ArtistsController : Controller
    {
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<IEnumerable<Artist>> Get()
        {
            return await _artistService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Artist> Get(int id)
        {
            return await _artistService.GetById(1);
        }

        [HttpPost]
        public async Task Post([FromBody] Artist artist)
        {
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Artist artist)
        {
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
        }
    }
}
