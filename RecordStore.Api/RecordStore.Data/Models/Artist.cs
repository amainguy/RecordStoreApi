using System.Collections;

namespace RecordStore.Data.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection Records { get; set; }
    }
}
