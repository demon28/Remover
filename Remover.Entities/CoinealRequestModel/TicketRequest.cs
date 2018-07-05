using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.CoinealRequestModel
{
    public class TicketRequest
    {
        public string code { get; set; }
        public string msg { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public decimal high { get; set; }
        public decimal vol { get; set; }
        public decimal last { get; set; }
        public decimal low { get; set; }
        public decimal buy { get; set; }
        public decimal sell { get; set; }
        public long time { get; set; }
    }

   
}
