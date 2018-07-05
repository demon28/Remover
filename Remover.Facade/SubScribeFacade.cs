using Remover.Entities;
using Remover.Entities.BiAnRequestModel;
using Remover.Entities.GateRequestModel;
using Remover.Entities.HBRequestModel;
using Remover.Entities.OKRequestModel;
using Remover.Entities.ZBRequsetModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using static Remover.Entities.EnumType;

namespace Remover.Facade
{
    public class SubScribeFacade : FacadeBase
    {

        List<EnumType.CoinType> CoinList;

        List<ExChangeBase> ExChanges;

        Dictionary<ExchangeType, ExChangeBase> exChangesList;

        public delegate decimal FuncHandle(ExChangeBase ex, CoinType coin);

        public delegate object FuncHandleAll(ExChangeBase ex, CoinType coin);


        public SubScribeFacade(List<CoinType> coinList, List<ExChangeBase> exChanges)
        {
            CoinList = coinList;
            ExChanges = exChanges;
        }


        public SubScribeFacade(Dictionary<ExchangeType, ExChangeBase> exChanges, List<EnumType.CoinType> coins)
        {
            exChangesList = exChanges;
            CoinList = coins;
        }

        public SubScribeFacade(Dictionary<ExchangeType, ExChangeBase> exChanges)
        {
            exChangesList = exChanges;
           
        }


        public DataTable Enter()
        {


            DataTable dt = new DataTable();
            dt.Columns.Add("交易所");


            foreach (var item in CoinList)
            {
                dt.Columns.Add(item.ToString());
            }

            for (int i = 0; i < ExChanges.Count; i++)
            {
                dt.Rows.Add();
                dt.Rows[i][0] = ExChanges[i].GetExchangeName();

                for (int j = 0; j < CoinList.Count; j++)
                {

                    FuncHandle fh = new FuncHandle(this.AscySingle);

                    IAsyncResult ar = fh.BeginInvoke(ExChanges[i], CoinList[j], null, fh);


                    dt.Rows[i][j + 1] = fh.EndInvoke(ar);
                }
            }

            return dt;
        }


        public decimal AscySingle(ExChangeBase ex, CoinType coin)
        {

         return  ex.GetSingleNowPrice(coin);

        }

        /// <summary>
        /// 获取所有币种所有价格组成DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllPrice() {

            DataTable dt = new DataTable();
            dt.Columns.Add("交易所");

            for (int i = 0; i < exChangesList.Count; i++)
            {

                var item = exChangesList.ElementAt(i);

                Dictionary<string, decimal> data =item.Value.GetAllPrice();

                dt.Columns.Add(item.Value.GetExchangeName());

                for (int j = 0; j < CoinList.Count; j++)
                {
                    dt.Rows.Add();
                    string val = CoinList[j].ToString().ToLower() + "_" + "usdt";
                    dt.Rows[j][0] = val;
                }
                for (int k = 0; k < CoinList.Count; k++)
                {
                    string val = CoinList[k].ToString().ToLower() + "_" + "usdt";

                    try {
                        dt.Rows[k][i + 1] = data.SingleOrDefault(S => S.Key.Equals(val)).Value;
                    }
                    catch
                    {
                        dt.Rows[k][i + 1] = 0;
                    }
                }

            }

            return dt;

        }




   


    }
}
