using Remover.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Remover.Entities.EnumType;

namespace Remover.Facade
{
    public class ExchangeFactory
    {

        public static ExChangeBase InstanExchange(ExchangeType exchange)
        {

            switch (exchange)
            {
                case ExchangeType.HuoBi:
                    return new HuoBiProduct(AppConfig.HuoBiApiAccessKey, AppConfig.HuoBiApiSeceretKey);

                   
                case ExchangeType.OKEX:

                    return null;
               
            }

            return null;

        }
    }
}