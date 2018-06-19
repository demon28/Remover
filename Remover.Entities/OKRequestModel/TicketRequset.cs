using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.OKRequestModel
{
    public class TicketRequset
    {
        /// <summary>
        /// 返回数据时服务器时间
        /// </summary>
       public string date;
        public TickerModel ticker;


    }

    public class TickerModel
    {
        /// <summary>
        /// 买一价
        /// </summary>
        public decimal buy;
        /// <summary>
        /// 最高价
        /// </summary>
        public decimal high;
        /// <summary>
        /// 最新成交价
        /// </summary>
        public decimal last;
        /// <summary>
        /// 最低价
        /// </summary>
        public decimal low;
        /// <summary>
        /// 卖一价
        /// </summary>
        public decimal sell;
        /// <summary>
        /// 成交量(最近的24小时)
        /// </summary>
        public decimal vol;
    }
}
