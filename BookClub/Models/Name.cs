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
         * Создал модель  пользователя  с атребутом [Key] бля бд чтобы  Login пользователя и клсюч были в бп по совместительству   
         * 
         */

        [Key]
        public string LoginID { get; set; }

       
    }
}
