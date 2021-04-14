using System;
using System.Collections.Generic;

namespace libary
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public DateTime Birthday { get; set; }

        public List<Book> Books { get; set; }

    }
}