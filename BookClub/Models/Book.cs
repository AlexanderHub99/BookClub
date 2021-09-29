using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub.Models
{
    public class Book
    /*
    * Создал модель прочтенных книг для бд и взаимодействия на View
    */
    {
        public int id { get; set; }

        public string NameBook { get; set; }
        public string imgBook { get; set; }



    }
}
