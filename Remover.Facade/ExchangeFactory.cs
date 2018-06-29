using Remover.Entities;
using Remover.Facade.Product;
using Remover.Facade.ZBAPI;
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

                case ExchangeType.BiAn:

                    return new BiAnProduct(AppConfig.BiAnApiKey, AppConfig.BiAnSecretKey);

                case ExchangeType.ZB:

                    return new ZBProduct(AppConfig.ZBApiKey, AppConfig.ZBSecretKey);
                case ExchangeType.Coineal:

                    return new CoinealProduct(AppConfig.EalApiKey, AppConfig.EalSecretKey);
            }

            return null;

        }
    }
}