using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remover.Entities;

namespace Remover.Facade.Ticket
{
    public class OkExTicket : TicketBase
    {
        private string AccessKey, SeceretKey;
        
        public OkExTicket(string HuoBiApiAccessKey, string HuoBiApiSeceretKey)
        {
            AccessKey = HuoBiApiAccessKey;
            SeceretKey = HuoBiApiSeceretKey;
            //api = new BiAnAPIFacade(AccessKey, SeceretKey);
        }

        public override bool CancelPending(string orderNo, string coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {
            throw new NotImplementedException();
        }

        public override decimal CheckBalances()
        {
            throw new NotImplementedException();
        }

        public override T ExchangePending<T>(decimal rate, decimal amount, string coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {
            throw new NotImplementedException();
        }
    }
}
