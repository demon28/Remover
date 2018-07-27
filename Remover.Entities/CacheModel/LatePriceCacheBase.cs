using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities
{
    public class LatePriceCacheBase
    {
        /// <summary>
        /// 平台ID
        /// </summary>
        public int PlatformId { get; set; }
        /// <summary>
        /// 平台代号
        /// </summary>
        public string PlatformCode { get; set; }
        /// <summary>
        /// 平台名称
        /// </summary>
        public string PlatfromName { get; set; }
        /// <summary>
        /// 交易对ID
        /// </summary>
        public int PairId { get; set; }
        /// <summary>
        /// 交易对代号
        /// </summary>
        public string PairCode { get; set; }
        /// <summary>
        /// 币种ID
        /// </summary>
        public int CurrencyId { get; set; }
        /// <summary>
        /// 币种Code
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// 支付货币ID
        /// </summary>
        public int ExCurrencyId { get; set; }
        /// <summary>
        /// 支付货币Code
        /// </summary>
        public string ExCurrencyCode { get; set; }        
        /// <summary>
        /// 买一价格
        /// </summary>
        public decimal BuyPrice { get; set; }
        /// <summary>
        /// 买一数量
        /// </summary>
        public decimal BuyCount { get; set; }
        /// <summary>
        /// 卖一价格
        /// </summary>
        public decimal SellPrice { get; set; }
        /// <summary>
        /// 卖一数量
        /// </summary>
        public decimal SellCount { get; set; }
        /// <summary>
        /// 最新时间
        /// </summary>
        public DateTime LateTime { get; set; }
        /// <summary>
        /// 买方深度
        /// </summary>
        public List<TickModel> Bids { get; set; }
        /// <summary>
        /// 卖方深度
        /// </summary>
        public List<TickModel> Asks { get; set; }
    }

    public class TickModel
    {
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 排序（从0开始）
        /// </summary>
        public decimal Sort { get; set; }
    }
}
