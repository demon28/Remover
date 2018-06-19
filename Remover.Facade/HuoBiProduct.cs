using Remover.Entities;
using Remover.Facade.HuoBiAPI;
using Remover.Entities.HBRequestModel;

namespace Remover.Facade
{

    /// <summary>
    /// 火币实例
    /// </summary>
    internal class HuoBiProduct : ExChangeBase
    {


        private string AccessKey, SeceretKey;

        HuoBiApiFacade api;

        public  HuoBiProduct(string HuoBiApiAccessKey, string HuoBiApiSeceretKey)
        {

            AccessKey = HuoBiApiAccessKey;
            SeceretKey = HuoBiApiSeceretKey;
            api = new HuoBiApiFacade(AccessKey, SeceretKey);
        }



        /// <summary>
        /// 获取单个币种在火币的价格
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public override decimal GetSingleNowPrice(EnumType.CoinType coin, EnumType.CurrencyType currency)
        {
            string Symbol = ConvertSymbolTool.HBConvertSymbol(coin, currency);

            var result = api.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);

            if (result.tick.ask.Length<=0)
            {
                return 0;
            }

            return result.tick.ask[0];
            
        }
    }
}
