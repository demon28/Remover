using Remover.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Remover.Entities.EnumType;

namespace Remover.Facade
{
   public   abstract class ExChangeBase
    {
        public abstract decimal  GetSingleNowPrice(CoinType coin,CurrencyType currency);

    }
}
