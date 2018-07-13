using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Remover.Entities.EnumType;

namespace Remover.Facade.Ticket
{
    public abstract class TicketBase
    {
        //获取账户余额
        public abstract decimal CheckBalances();

        //交易挂单
        public abstract T ExchangePending<T>(decimal rate, decimal amount, string coin, CurrencyType currency = CurrencyType.USDT) where T : new();
        
        //撤单
        public abstract bool CancelPending(string orderNo,string coin, CurrencyType currency = CurrencyType.USDT);
        
        //查询成交历史
        
    }
}
