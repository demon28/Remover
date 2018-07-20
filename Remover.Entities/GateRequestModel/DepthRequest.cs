using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.GateRequestModel
{
    public class DepthRequest
    {
        public bool result { get; set; }

        public decimal[][] bids;

        public decimal[][] asks;
    }
}
