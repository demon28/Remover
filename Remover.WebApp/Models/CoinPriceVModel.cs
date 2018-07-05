using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Remover.WebApp.Models
{
    public class CoinPriceVModel
    {
        public List<TitleVModel> TitleVModels { get; set; }

        public List<CoinInfoVModel> CoinInfoVModels { get; set; }

        public List<CoinComparedVModel> CoinComparedVModels { get; set; }
    }

    public class TitleVModel
    {
        /// <summary>
        /// 表头
        /// </summary>
        public string TitleName { get; set; }
    }
    
    public class CoinInfoVModel
    {
        /// <summary>
        /// 币名称
        /// </summary>
        public string CoinName { get; set; }
        /// <summary>
        /// 相差值
        /// </summary>
        public decimal Difference { get; set; }
        /// <summary>
        /// 价格序列
        /// </summary>
        public List<PriceVModel> PriceVModels { get; set; }
    }

    public class PriceVModel
    {
        /// <summary>
        /// 平台名称
        /// </summary>
        public string PlatformName { get; set; }
        /// <summary>
        /// 币名称
        /// </summary>
        public string CoinName { get; set; }
        /// <summary>
        /// 当前售价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 买一价格
        /// </summary>
        public decimal BuyPrice { get; set; }
        /// <summary>
        /// 卖一价格
        /// </summary>
        public decimal SellPrice { get; set; }
        /// <summary>
        /// 是否最高和最低
        /// </summary>
        public int IsMaxAndMin { get; set; }
    }

    public class CoinComparedVModel
    {
        /// <summary>
        /// 币名
        /// </summary>
        public string CoinName { get; set; }
        /// <summary>
        /// 最高价
        /// </summary>
        public decimal MaxPrice { get; set; }
        /// <summary>
        /// 最低价
        /// </summary>
        public decimal MinPrice { get; set; }
        /// <summary>
        /// 差值
        /// </summary>
        public decimal Difference { get; set; }
    }
}