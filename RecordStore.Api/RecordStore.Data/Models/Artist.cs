using System.Collections.Generic;

namespace RecordStore.Data.Models
{
    public class Artist : BaseEntity, IShareableId
    {
        public int ArtistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Record> Records { get; set; }

        public int GetId()
        {
            return ArtistId;
        }
    }
}
