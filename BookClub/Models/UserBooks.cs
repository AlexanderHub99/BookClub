using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub.Models
{
    public class UserBooks
    {
        /*
         * Создал модель прочитанных книг для бд и взаимодействия на View
         */
        public int id { get; set; }
        public string LoginName { get; set; }
        public string SelectedBook { get; set; }
    }
}
