using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities
{
    public class StringProcess
    {
        /// <summary>
        /// 获取Api格式化参数
        /// </summary>
        /// <param name="currency">交易币种</param>
        /// <param name="exCurrency">支付币种</param>
        /// <param name="type">取值类型</param>
        /// <param name="apiType">接口名称</param>
        /// <returns>例如:market.btcusdt.depth.step0</returns>
        public static string HuoBiString(string currency,string exCurrency, string apiType= "depth", string type = "step0")
        {
            string str = string.Format("market.{0}{1}.{2}.{3}", currency.ToLower(), exCurrency.ToLower(), apiType, type);
            return str;
        }

        /// <summary>
        /// 拆解字符串,取字符串当中的段
        /// </summary>
        /// <param name="collection">字符串，例如:market.btcusdt.depth.step0</param>
        /// <param name="segment">取第几段（从0开始）,默认取第二段</param>
        /// <returns>BTCUSDT</returns>
        public static string HuoBiStringSplit(string collection,int segment=1)
        {
            if(collection.IndexOf('.')==0|| string.IsNullOrEmpty(collection))
            {
                return string.Empty;
            }
            string[] spStr = collection.Split('.');
            return spStr[segment].ToUpper();
        }

    }
}
