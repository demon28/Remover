using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.BiAnRequestModel
{
    public class DepthRequest
    {
        public string lastUpdateId { get; set; }

        public object[][] bids;

        public object[][] asks;
    }


    

}
