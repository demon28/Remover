using Remover.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using static Remover.Entities.EnumType;

namespace Remover.Facade
{
    public class SubScribeFacade : FacadeBase
    {

        List<EnumType.CoinType> CoinList;

        ExChangeBase exchange1 = ExchangeFactory.InstanExchange(ExchangeType.HuoBi);
        ExChangeBase exchange2 = ExchangeFactory.InstanExchange(ExchangeType.OKEX);
        ExChangeBase exchange3 = ExchangeFactory.InstanExchange(ExchangeType.Gate);
        ExChangeBase exchange4 = ExchangeFactory.InstanExchange(ExchangeType.BiAn);
        ExChangeBase exchange5 = ExchangeFactory.InstanExchange(ExchangeType.ZB);


        public SubScribeFacade(List<Entities.EnumType.CoinType> coinList)
        {
            CoinList = coinList;

        }


        public DataTable Enter()
        {

            List<ExChangeBase> exChanges = new List<ExChangeBase>();
            exChanges.Add(exchange1);
            exChanges.Add(exchange2);
            exChanges.Add(exchange3);
            exChanges.Add(exchange4);
            exChanges.Add(exchange5);

            DataTable dt = new DataTable();
            dt.Columns.Add("交易所");


            foreach (var item in CoinList)
            {
                dt.Columns.Add(item.ToString());
            }

            for (int i = 0; i < exChanges.Count; i++)
            {
                dt.Rows.Add();
                dt.Rows[i][0] = exChanges[i].GetExchangeName();

                for (int j = 0; j < CoinList.Count; j++)
                {
                    dt.Rows[i][j+1] = exChanges[i].GetSingleNowPrice(CoinList[j]);
                }
            }

            return dt;
        }



    }
}
