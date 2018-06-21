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

            Dictionary<string, decimal> dataBiAn = new Dictionary<string, decimal>();
           Dictionary<string, decimal> dataHuobi = new Dictionary<string, decimal>();
            Dictionary<string, decimal> dataGateIO = new Dictionary<string, decimal>();
            Dictionary<string, decimal> dataOkEx = new Dictionary<string, decimal>();
            Dictionary<string, decimal> dataZb = new Dictionary<string, decimal>();

            if (exChangesList.Keys.Contains(Entities.EnumType.ExchangeType.BiAn))
            {
                dataBiAn = AllBiAn(exChangesList[ExchangeType.BiAn]);
                dt.Columns.Add(ExchangeType.BiAn.ToString());
            }


            if (exChangesList.Keys.Contains(Entities.EnumType.ExchangeType.HuoBi))
            {
                dataHuobi = AllHuobi(exChangesList[ExchangeType.HuoBi]);
                dt.Columns.Add(ExchangeType.HuoBi.ToString());

            }


            if (exChangesList.Keys.Contains(Entities.EnumType.ExchangeType.Gate))
            {
                dataGateIO = AllGateIO(exChangesList[ExchangeType.Gate]);
                dt.Columns.Add(ExchangeType.Gate.ToString());
            }

            if (exChangesList.Keys.Contains(Entities.EnumType.ExchangeType.OKEX))
            {
                dataOkEx = AllOkEx(exChangesList[ExchangeType.OKEX]);
                dt.Columns.Add(ExchangeType.OKEX.ToString());
            }

            if (exChangesList.Keys.Contains(Entities.EnumType.ExchangeType.ZB))
            {
                dataZb = AllZb(exChangesList[ExchangeType.ZB]);
                dt.Columns.Add(ExchangeType.ZB.ToString());
            }


            for (int i=0;i<CoinList.Count;i++)
            {
                dt.Rows.Add();

                string val = CoinList[i].ToString().ToLower() + "_" + "usdt";
                dt.Rows[i][0] = val;
                try
                {
                    dt.Rows[i][1] = dataBiAn.SingleOrDefault(S => S.Key.Equals(val)).Value;
                }
                catch
                {
                    dt.Rows[i][1] = "无";
                }

                try
                {
                    dt.Rows[i][2] = dataHuobi.SingleOrDefault(S => S.Key.Equals(val)).Value;
                }
                catch
                {
                    dt.Rows[i][2] = "无";
                }

                try
                {
                    dt.Rows[i][3] = dataGateIO.SingleOrDefault(S => S.Key.Equals(val)).Value;
                }
                catch
                {
                    dt.Rows[i][3] = "无";
                }

                try
                {
                    dt.Rows[i][4] = dataOkEx.SingleOrDefault(S => S.Key.Equals(val)).Value;
                }
                catch
                {
                    dt.Rows[i][4] = "无";
                }

                try
                {
                    dt.Rows[i][5] = dataZb.SingleOrDefault(S => S.Key.Equals(val)).Value;

                }
                catch
                {
                    dt.Rows[i][5] = "无";
                }
                
            }





            return dt;

        }

        private Dictionary<string, decimal> AllGateIO(ExChangeBase ex)
        {
            return ex.GetAllPrice();
        }

        private Dictionary<string, decimal> AllZb(ExChangeBase ex)
        {
            return ex.GetAllPrice();
        }

        private Dictionary<string, decimal> AllOkEx(ExChangeBase ex)
        {
            return  ex.GetAllPrice();
        }

        private Dictionary<string, decimal> AllHuobi(ExChangeBase ex)
        {
            return ex.GetAllPrice();
        }

        private Dictionary<string, decimal> AllBiAn(ExChangeBase ex)
        {
            return ex.GetAllPrice();
        }

      



   


    }
}
