using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PurchaseStatusDTO
    {
        public int ID { get; set; }
        public string StatusName { get; set; }
        public bool PurchaseStatus   { get; set; }
        public DateTime DateTime { get; set; }
    }
}
