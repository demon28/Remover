using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Remover.Entities.HBRequestModel
{
    public class TicketRequest
    {

        /// <summary>
        /// 请求处理结果
        /// </summary>
        public string status;

        /// <summary>
        /// 响应生成时间点，单位：毫秒
        /// </summary>
        public decimal ts;

        /// <summary>
        /// K线数据
        /// </summary>
        public TicketModel tick;

        /// <summary>
        /// 数据所属的 channel，格式： market.$symbol.detail.merged
        /// </summary>
        public string ch;
    }


    public class TicketModel
    {

        /// <summary>
        ///  K线id,
        /// </summary>
        public decimal id;
        /// <summary>
        /// 成交量,
        /// </summary>
        public decimal amount;
        /// <summary>
        /// 成交笔数
        /// </summary>
        public decimal count;
        /// <summary>
        /// 开盘价
        /// </summary>
        public decimal open;
        /// <summary>
        /// 收盘价,当K线为最晚的一根时，是最新成交价
        /// </summary>
        public decimal close;
        /// <summary>
        /// 最低价,
        /// </summary>
        public decimal low;
        /// <summary>
        /// 最高价
        /// </summary>
        public decimal high;
        /// <summary>
        ///  成交额, 即 sum(每一笔成交价* 该笔的成交量)
        /// </summary>
        public decimal vol;
        /// <summary>
        ///  [买1价, 买1量],
        /// </summary>
        public decimal[] bid;
        /// <summary>
        /// [卖1价,卖1量]
        /// </summary>
        public decimal[] ask;



    }

}
