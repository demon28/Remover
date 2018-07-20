using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.OKRequestModel
{
    public class DepthRequest
    {
        public decimal[][] bids { get; set; }

        public decimal[][] asks { get; set; }
    }
}
