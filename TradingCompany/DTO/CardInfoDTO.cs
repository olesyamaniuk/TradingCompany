using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTO
{
    public class CardInfoDTO
    {
        public long CardInfoID { get; set; }
    
        public string CardNumber { get; set; }
        public int CVV { get; set; }
       
        public System.DateTime ExtendDate { get; set; }

    }
}
