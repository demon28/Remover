using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities
{
    public class LatePriceModel
    {
        public List<PriceModel> Bids { get; set; }
        public List<PriceModel> Asks { get; set; }
    }

    public class PriceModel
    {
        public decimal price { get; set; }

        public decimal amount { get; set; }
    }

}
