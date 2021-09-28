using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub.Models
{
    public class UserBooks
    {
        /*
         * Созал модель прочитанных книг бля бд и взаимодествия на View
         */
        public int id { get; set; }
        public string LoginName { get; set; }
        public string SelectedBook { get; set; }
    }
}
