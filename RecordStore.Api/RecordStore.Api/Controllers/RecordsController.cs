using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecordStore.DomainObjects;
using RecordStore.Services.Interfaces;

namespace RecordStore.Api.Controllers
{
    [Route("api/records")]
    public class RecordsController : Controller
    {
        public IRecordService _recordService;

        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var artists = await _recordService.GetAll();
            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await _recordService.GetById(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public async Task Create([FromBody] RecordDo record)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] RecordDo record)
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
