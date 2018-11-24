namespace RecordStore.Data.Models
{
    public class Record : BaseEntity, IShareableId
    {
        public int RecordId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public int GetId()
        {
            return RecordId;
        }
    }
}
