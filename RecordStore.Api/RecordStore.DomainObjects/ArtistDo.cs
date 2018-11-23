using System.Collections.Generic;

namespace RecordStore.DomainObjects
{
    public class ArtistDo
    {
        public int ArtistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<RecordDo> Records { get; set; }
    }
}
