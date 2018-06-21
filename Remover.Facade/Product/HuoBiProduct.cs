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

        public HuoBiProduct(string HuoBiApiAccessKey, string HuoBiApiSeceretKey)
        {

            AccessKey = HuoBiApiAccessKey;
            SeceretKey = HuoBiApiSeceretKey;
            api = new HuoBiApiFacade(AccessKey, SeceretKey);
        }

        public override string GetExchangeName()
        {
            return "火币";
        }



        /// <summary>
        /// 获取单个币种在火币的价格
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public override decimal GetSingleNowPrice(EnumType.CoinType coin, EnumType.CurrencyType currency = EnumType.CurrencyType.USDT)
        {

            try
            {
                string Symbol = ConvertSymbolTool.HBConvertSymbol(coin, currency);

                var result = api.SendRequestContent<TicketRequest>(ApiUrlList.API_Ticker, Symbol);

                if (result.tick.ask.Length <= 0)
                {
                    return 0;
                }

                return decimal.Parse(result.tick.ask[0].ToString("f3"));
            }
            catch
            {
                return 0;
            }
           
        }
    }
}
