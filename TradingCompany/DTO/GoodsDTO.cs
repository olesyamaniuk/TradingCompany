using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GoodsDTO
    {
        public int GoodsID { get; set; }
        public string GoodsName { get; set; }
        public string GoodsPrice { get; set; }
        public string GoodsDescription { get; set; }
        public string GoodsAmount { get; set; }

        public int SepetID { get; set; }

    }
}
