using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.HBRequestModel
{

    public class MarketRequestModel
    {
        public string status { get; set; }
        public long ts { get; set; }
        public List<Datum> data { get; set; }
    }

    public class Datum
    {
        public decimal open { get; set; }
        public decimal close { get; set; }
        public decimal low { get; set; }
        public decimal high { get; set; }
        public decimal amount { get; set; }
        public int count { get; set; }
        public decimal vol { get; set; }
        public string symbol { get; set; }
    }
}
