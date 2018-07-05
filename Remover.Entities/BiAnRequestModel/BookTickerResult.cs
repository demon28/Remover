using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.BiAnRequestModel
{
    public class BookTickerResult
    {
        public string symbol { get; set; }
        public decimal bidPrice { get; set; }
        public decimal bidQty { get; set; }
        public decimal askPrice { get; set; }
        public decimal askQty { get; set; }
    }
}
