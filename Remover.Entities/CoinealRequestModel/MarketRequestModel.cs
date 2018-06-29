using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.CoinealRequestModel
{
  
        public class MarketRequest
        {
            public string code { get; set; }
            public string msg { get; set; }
            public Dictionary<string,decimal> data { get; set; }
        }
     
    


}
