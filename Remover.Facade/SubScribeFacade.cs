using Remover.Entities;
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


        public delegate decimal FuncHandle(ExChangeBase ex, CoinType coin);

        public SubScribeFacade(List<CoinType> coinList, List<ExChangeBase> exChanges)
        {
            CoinList = coinList;
            ExChanges = exChanges;
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

            return ex.GetSingleNowPrice(coin);

        }


    }
}
