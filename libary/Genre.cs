﻿using System;
using System.Collections.Generic;
using System.Text;

namespace libary
{
   public class Genre
   {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
   }
}
