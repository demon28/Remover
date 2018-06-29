using Remover.Entities;
using Remover.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Remover.Entities.EnumType;

namespace Remover
{
    public partial class Form1 : Form
    {
        List<CoinType> coinTypes = new List<CoinType>();
        public Form1()
        {
            InitializeComponent();

            coinTypes.Add(CoinType.BTC);
            coinTypes.Add(CoinType.EOS);
            coinTypes.Add(CoinType.ETH);
        }

     
   

        private void button1_Click_1(object sender, EventArgs e)
        {





            ExChangeBase exchange1 = ExchangeFactory.InstanExchange(ExchangeType.HuoBi);
            ExChangeBase exchange2 = ExchangeFactory.InstanExchange(ExchangeType.OKEX);
            ExChangeBase exchange3 = ExchangeFactory.InstanExchange(ExchangeType.Gate);
            ExChangeBase exchange4 = ExchangeFactory.InstanExchange(ExchangeType.BiAn);
            ExChangeBase exchange5 = ExchangeFactory.InstanExchange(ExchangeType.ZB);
            ExChangeBase exchange6 = ExchangeFactory.InstanExchange(ExchangeType.Coineal);

            //List<ExChangeBase> exChanges = new List<ExChangeBase>();
            //exChanges.Add(exchange1);
            //exChanges.Add(exchange2);
            //exChanges.Add(exchange3);
            //exChanges.Add(exchange4);
            //exChanges.Add(exchange5);


            Dictionary<ExchangeType, ExChangeBase> exChangesList = new Dictionary<ExchangeType, ExChangeBase>();
          //  exChangesList.Add(ExchangeType.HuoBi, exchange1);
        //    exChangesList.Add(ExchangeType.OKEX, exchange2);
            exChangesList.Add(ExchangeType.Gate, exchange3);
            //  exChangesList.Add(ExchangeType.BiAn, exchange4);
            //  exChangesList.Add(ExchangeType.ZB, exchange5);
            exChangesList.Add(ExchangeType.Coineal, exchange6);

            SubScribeFacade subScribeFacade = new SubScribeFacade(exChangesList, coinTypes);

            dataGridView1.DataSource = subScribeFacade.GetAllPrice();


       

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExChangeBase exchange5 = ExchangeFactory.InstanExchange(ExchangeType.Coineal);

            exchange5.GetSingleNowPrice(CoinType.ETH,CurrencyType.USDT);
        }
    }
}
