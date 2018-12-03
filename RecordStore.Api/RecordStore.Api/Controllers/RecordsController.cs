using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecordStore.DomainObjects;
using RecordStore.Services.Interfaces;

namespace RecordStore.Api.Controllers
{
    [Route("api/records")]
    public class RecordsController : BaseController
    {
        private const string RecordShouldNotBeNull = "RecordShouldNotBeNull";
        private const string ValidRecordIdShouldBeProvided = "A valid record id should be provided";
        public IRecordService _recordService;

        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var records = await _recordService.GetAll();
            return Ok(records);
        }

        [HttpGet("{id}", Name = "GetRecordById")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await _recordService.GetById(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpGet("{id}/artist")]
        public async Task<IActionResult> GetByIdWithArtist(int id)
        {
            var record = await _recordService.GetById(id, loadArtist: true);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RecordDo record)
        {
            if (record == null)
                return BadRequest(RecordShouldNotBeNull);

            return await TryExecutingServiceAsync(() => _recordService.Create(record), CreatedAtRoute("GetRecordById", new {id = record.RecordId}, record));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RecordDo record)
        {
            if (record == null)
                return BadRequest(RecordShouldNotBeNull);
            if (id == 0)
                return BadRequest(ValidRecordIdShouldBeProvided);

            return await TryExecutingServiceAsync(() => _recordService.Update(id, record), Ok());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RecordDo record)
        {
            if (record == null)
                return BadRequest(RecordShouldNotBeNull);

            return await TryExecutingServiceAsync(() => _recordService.Delete(record), Ok());
        }
    }
}
