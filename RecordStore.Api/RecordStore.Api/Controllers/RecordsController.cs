using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecordStore.DomainObjects;

namespace RecordStore.Api.Controllers
{
    [Route("api/records")]
    public class RecordsController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<Record>> Get()
        {
            return new List<Record>();
        }

        [HttpGet("{id}")]
        public async Task<Record> Get(int id)
        {
            return new Record { Id = 1 };
        }

        [HttpPost]
        public async Task Post([FromBody] Record record)
        {
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Record record)
        {
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
        }
    }
}
