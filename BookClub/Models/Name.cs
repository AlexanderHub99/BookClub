using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub.Models
{
    public class Name
    {
        /*
         * Создал модель  пользователя  с атрибутом [Key] бля бд чтобы  Login пользователя и ключ были в бд по совместительству   
         * 
         */

        [Key]
        public string LoginID { get; set; }


    }
}
