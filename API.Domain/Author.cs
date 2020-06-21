using System;

namespace API.Domain
{
    public class Author: DomainBase
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
