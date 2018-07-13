using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Remover.WebApp.Models
{
    public class QuoteModel
    {
        public int QuotesId { get; set; }
        public int CoinId { get; set; }
        public int PlatformId { get; set; }
        public string CoinName { get; set; }
        public string Market { get; set; }
        public decimal Price { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int CurrencyType { get; set; }
        public string Timestamps { get; set; }
        public string CreateTime { get; set; }
        public string PlatformName { get; set; }
    }
}