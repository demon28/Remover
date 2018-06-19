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
    public class ExchangeFactory:FacadeBase
    {

        public static ExChangeBase InstanExchange(ExchangeType exchange)
        {

            switch (exchange)
            {
                case ExchangeType.HuoBi:
                    return new HuoBiProduct(AppConfig.HuoBiApiAccessKey, AppConfig.HuoBiApiSeceretKey);
                   
                case ExchangeType.OKEX:

                    return new OkExProduct(AppConfig.OkExApiKey, AppConfig.OkExSecretKey);

                case ExchangeType.Gate:

                    return new GateProduct(AppConfig.GateApiKey, AppConfig.GateSecretKey);

            }

            return null;

        }
    }
}