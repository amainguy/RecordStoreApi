using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RecordStore.DomainObjects;

namespace RecordStore.Api.Controllers
{
    [Route("api/records")]
    public class RecordsController : Controller
    {
        [HttpGet]
        public IEnumerable<Record> Get()
        {
            return new List<Record>();
        }

        [HttpGet("{id}")]
        public Record Get(int id)
        {
            return new Record { Id = 1 };
        }

        [HttpPost]
        public void Post([FromBody] Record record)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Record record)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
