using System;
using System.Collections.Generic;

namespace libary
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public List<Genre> Genres { get; set; }
        public Publisher Publisher { get; set; }
        public List<Author> Authors { get; set; }
        //public Genre Genre { get; set; }
    }
}