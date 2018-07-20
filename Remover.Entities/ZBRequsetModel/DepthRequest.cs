using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.ZBRequsetModel
{
    public class DepthRequest
    {
        public string timestamp { get; set; }
        public decimal[][] bids { get; set; }

        public decimal[][] asks { get; set; }
    }
}
