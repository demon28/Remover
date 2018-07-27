using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities
{
    public class VmpConfigModel
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
        public string PlatformName { get; set; }
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
        /// 交易对合并标记
        /// </summary>
        public string Mark { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        public int ConfigId { get; set; }
    }
}
