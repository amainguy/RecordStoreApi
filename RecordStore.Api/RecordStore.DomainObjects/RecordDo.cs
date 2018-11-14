namespace RecordStore.DomainObjects
{
    public class RecordDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public ArtistDo Artist { get; set; }
    }
}
