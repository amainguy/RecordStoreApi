using System;

namespace RecordStore.Data.Models
{
    public class BaseEntity
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
