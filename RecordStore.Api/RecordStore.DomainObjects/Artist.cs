using System.Collections.Generic;

namespace RecordStore.DomainObjects
{
    public class Artist
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Record> Records { get; set; }
    }
}
