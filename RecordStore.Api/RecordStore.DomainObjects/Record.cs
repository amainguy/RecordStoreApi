namespace RecordStore.DomainObjects
{
    public class Record
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public Artist Artist { get; set; }
    }
}
