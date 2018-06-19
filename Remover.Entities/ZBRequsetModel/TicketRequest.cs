using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities.ZBRequsetModel
{
   public class TicketRequest
    {
        public string date;

        public TickerModel ticker;

       
    }


    public class TickerModel
    {

        /// <summary>
        /// 成交量(最近的24小时)
        /// </summary>
        public decimal vol;
        /// <summary>
        /// 最新成交价
        /// </summary>
        public decimal last;
        /// <summary>
        /// 卖一价
        /// </summary>
        public decimal sell;
        /// <summary>
        /// 买一价
        /// </summary>
        public decimal buy;
        /// <summary>
        /// 最高价
        /// </summary>
        public decimal high;
        /// <summary>
        /// 最低价
        /// </summary>
        public decimal low;
  
        }
}
