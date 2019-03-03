using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecordStore.DomainObjects;
using RecordStore.Services.Interfaces;

namespace RecordStore.Api.Controllers
{
    
    [Route("api/artists")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ArtistsController : BaseController
    {
        private const string ArtistShouldNotBeNull = "Artist should not be null";
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var artists = await _artistService.GetAll();
            return Ok(artists);
        }

        [HttpGet("{id}", Name = "GetArtistById")]
        public async Task<IActionResult> GetById(int id)
        {
            var artist = await _artistService.GetById(id);
            if (artist == null)
                return NotFound();
            return Ok(artist);
        }

        [HttpGet, Route("{id}/discography")]
        public async Task<IActionResult> GetByIdWithDiscography(int id)
        {
            var artist = await _artistService.GetById(id, loadRecords: true);
            if (artist == null)
                return NotFound();
            return Ok(artist);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArtistDo artist)
        {
            if (artist == null)
                return BadRequest(ArtistShouldNotBeNull);

            return await TryExecutingServiceAsync(() => _artistService.Create(artist), CreatedAtRoute("GetArtistById", new {id = artist.ArtistId, artist}) );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ArtistDo artist)
        {
            if (artist == null)
                return BadRequest(ArtistShouldNotBeNull);
            if (id == 0)
                return BadRequest("You must provide an id in order to retrieve the artist");

            return await TryExecutingServiceAsync(() => _artistService.Update(id, artist), Ok());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ArtistDo artist)
        {
            if (artist == null)
                return BadRequest(ArtistShouldNotBeNull);

            return await TryExecutingServiceAsync(() => _artistService.Delete(artist), Ok());
        }
    }
}
