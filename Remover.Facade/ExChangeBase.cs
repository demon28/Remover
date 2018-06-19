using Remover.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using static Remover.Entities.EnumType;

namespace Remover.Facade
{
   public   abstract class ExChangeBase:FacadeBase
    {
        /// <summary>
        /// 获取单个币种的当前价格
        /// </summary>
        /// <param name="coin">币种</param>
        /// <param name="currency">锚定单位</param>
        /// <returns></returns>
        public abstract decimal  GetSingleNowPrice(CoinType coin,CurrencyType currency);



    }
}
