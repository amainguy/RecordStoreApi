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
        public async Task<IEnumerable<ArtistDo>> Get()
        {
            return await _artistService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ArtistDo> Get(int id)
        {
            return await _artistService.GetById(1);
        }

        [HttpPost]
        public async Task Post([FromBody] ArtistDo artist)
        {
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ArtistDo artist)
        {
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
        }
    }
}
