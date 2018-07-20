using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.HBRequestModel
{
    public class DepthRequest
    {
        public string status { get; set; }
        public string ch { get; set; }
        public string ts { get; set; }
        public Tick tick { get; set; }
    }

    public class Tick
    {
        public string id { get; set; }
        
        public string ts { get; set; }

        public decimal[][] bids { get; set; }

        public decimal[][] asks { get; set; }
    }
}



