using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.GateRequestModel
{
    public class TicketRequest
    {
    
        /// <summary>
        /// 最新成交价
        /// </summary>
        public decimal last;
        /// <summary>
        /// 卖方最低价
        /// </summary>
        public decimal lowestAsk;
        /// <summary>
        /// 买方最高价
        /// </summary>
        public decimal highestBid;  
        /// <summary>
        /// 涨跌百分比
        /// </summary>
        public decimal percentChange;
        /// <summary>
        /// 交易量
        /// </summary>
        public decimal baseVolume;
        /// <summary>
        /// 兑换货币交易量
        /// </summary>
        public decimal quoteVolume;
        /// <summary>
        /// 24小时最高价
        /// </summary>
        public decimal high24hr;
        /// <summary>
        /// 24小时最低价
        /// </summary>
        public decimal low24hr;
    }
}
