using System.Collections.Generic;
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
        public async Task<IEnumerable<RecordDo>> Get()
        {
            return await _recordService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<RecordDo> Get(int id)
        {
            return await _recordService.GetById(1);
        }

        [HttpPost]
        public async Task Post([FromBody] RecordDo record)
        {
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] RecordDo record)
        {
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
        }
    }
}
