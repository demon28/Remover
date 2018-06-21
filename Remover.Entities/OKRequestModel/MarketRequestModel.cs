using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.OKRequestModel
{
  
        public class MarketRequestModel
    {
            public string date { get; set; }
            public List<Ticker> tickers { get; set; }
        }

        public class Ticker
        {
            public string symbol { get; set; }
            public decimal high { get; set; }
            public decimal vol { get; set; }
            public decimal last { get; set; }
            public decimal low { get; set; }
            public decimal buy { get; set; }
            public decimal sell { get; set; }
        }

   
}
