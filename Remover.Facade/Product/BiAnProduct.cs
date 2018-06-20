using Remover.Entities;
using Remover.Entities.BiAnRequestModel;
using Remover.Facade.BiAnAPI;

namespace Remover.Facade
{
    public class BiAnProduct:ExChangeBase
    {

        private string AccessKey, SeceretKey;

        BiAnAPIFacade api;

        public BiAnProduct(string HuoBiApiAccessKey, string HuoBiApiSeceretKey)
        {

            AccessKey = HuoBiApiAccessKey;
            SeceretKey = HuoBiApiSeceretKey;
            api = new BiAnAPIFacade(AccessKey, SeceretKey);
        }

        public override string GetExchangeName()
        {
            return "币安";
        }

        /// <summary>
        /// 获取单个币种在火币的价格
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public override decimal GetSingleNowPrice(EnumType.CoinType coin, EnumType.CurrencyType currency=EnumType.CurrencyType.USDT)
        {
            string Symbol = ConvertSymbolTool.BiAnConvertSymbol(coin, currency);

            var result = api.SendRequestContent<TicketRequest>(ApiUrlList.Url_Ticker, Symbol);

            if (result.lastPrice<= 0)
            {
                return 0;
            }

            return result.lastPrice;

        }

        
    }
}
