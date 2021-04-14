using System.Collections.Generic;

namespace libary
{
    public class Publisher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } // тебе руку никто не пожмет после этого
        public List<Book> Books { get; set; }
    }
}