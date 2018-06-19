using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Remover.Entities.OKRequestModel;
using Winner.Framework.Core.Facade;

namespace Remover.Facade.OkExAPI
{
    class OkExAPIFacade:FacadeBase
    {


        private string AccessKey, SeceretKey;
        private StockRestApi stockRest;
        public OkExAPIFacade(string acckey,string seckey)
        {
            AccessKey = acckey;
            SeceretKey = seckey;
           stockRest = new StockRestApi(AccessKey, SeceretKey);


        }


         public TicketRequset GetTicker(string symbol)
        {

            var result = stockRest.ticker(symbol);

            if (result==string.Empty ||result==null)
            {
                Alert("请求失败！");
                return null;
            }


            TicketRequset ticketRequset = JsonConvert.DeserializeObject<TicketRequset>(result);

            return ticketRequset;

        }


    }
}
