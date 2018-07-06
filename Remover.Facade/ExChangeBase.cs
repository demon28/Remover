using Remover.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Winner.Framework.Utils;
using static Remover.Entities.EnumType;

namespace Remover.Facade
{
    public abstract class ExChangeBase : FacadeBase
    {
        /// <summary>
        /// 获取单个币种的当前价格
        /// </summary>
        /// <param name="coin">币种</param>
        /// <param name="currency">锚定单位</param>
        /// <returns></returns>
        public abstract decimal GetSingleNowPrice(CoinType coin, CurrencyType currency = CurrencyType.USDT);

        /// <summary>
        /// 获取单个币种买一价，卖一价，当前价
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public abstract BasePriceModel GetNowPrice(string coin, CurrencyType currency = CurrencyType.USDT);

        /// <summary>
        /// 获取交易所名称
        /// </summary>
        /// <returns></returns>
        public abstract string GetExchangeName();


        /// <summary>
        /// 获取交易所所有币价
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected abstract Dictionary<string, decimal> GetAllPrice();
        public Dictionary<string, decimal> GetPrice()
        {
            Log.Info("START GET PRICE:" + GetExchangeName());
            var res =new Dictionary<string, decimal>();
            try
            {
                res = GetAllPrice();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            Log.Info("GET PRICE FINIESHED:" + GetExchangeName());
            return res;
        }
    }
}
