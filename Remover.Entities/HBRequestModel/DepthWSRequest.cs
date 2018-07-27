using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.HBRequestModel
{
    public class DepthWSRequest
    {
        public string ch { get; set; }
        public long ts { get; set; }
        public Ticket tick { get; set; }
    }

    public class Ticket
    {
        public decimal[][] bids { get; set; }
        public decimal[][] asks { get; set; }
    }

}
