using System;
using System.Collections.Generic;
using System.Text;

namespace RecordStore.DomainObjects
{
    public class UserDo
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}
