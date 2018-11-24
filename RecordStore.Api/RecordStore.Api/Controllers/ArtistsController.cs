using System;
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
        public async Task<IActionResult> Get()
        {
            var artists = await _artistService.GetAll();
            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var artist = await _artistService.GetById(id);
            if (artist == null)  return NotFound();
            return Ok(artist);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArtistDo artist)
        {
            throw  new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] ArtistDo artist)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
