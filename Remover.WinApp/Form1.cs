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

        Dictionary<ExchangeType, ExChangeBase> exChangesList = new Dictionary<ExchangeType, ExChangeBase>();


        ExChangeBase exchange1 = ExchangeFactory.InstanExchange(ExchangeType.HuoBi);
        ExChangeBase exchange2 = ExchangeFactory.InstanExchange(ExchangeType.OKEX);
        ExChangeBase exchange3 = ExchangeFactory.InstanExchange(ExchangeType.Gate);
        ExChangeBase exchange4 = ExchangeFactory.InstanExchange(ExchangeType.BiAn);
        ExChangeBase exchange5 = ExchangeFactory.InstanExchange(ExchangeType.ZB);
        ExChangeBase exchange6 = ExchangeFactory.InstanExchange(ExchangeType.Coineal);


        public Form1()
        {
            InitializeComponent();

            coinTypes.Add(CoinType.BTC);
            coinTypes.Add(CoinType.EOS);
            coinTypes.Add(CoinType.ETH);
            coinTypes.Add(CoinType.LTC);



            exChangesList.Add(ExchangeType.HuoBi, exchange1);
            exChangesList.Add(ExchangeType.OKEX, exchange2);
            exChangesList.Add(ExchangeType.Gate, exchange3);
            exChangesList.Add(ExchangeType.BiAn, exchange4);
            exChangesList.Add(ExchangeType.ZB, exchange5);
        }



        Object obj = new object();

        private void button1_Click_1Async(object sender, EventArgs e)
        {
            BindAsync();
        }

        private async void MonitorsAsync()
        {
            await Task.Run(() =>
            {
                DataTable dt = (dataGridView1.DataSource as DataTable);

                for (int i = 0; i < exChangesList.Count; i++)
                {
                    for (int j = 0; j < coinTypes.Count; j++)
                    {
                        lock (obj)
                        {
                            dt.Rows[j][i + 1] = exChangesList.ElementAt(i).Value.GetSingleNowPrice(coinTypes[j]);
                            dataGridView1.DataSource = dt;
                        }

                    }
                }

            });

        }


        public async Task BindAsync()
        {

            dataGridView1.DataSource = await Task.Run(() =>
        {
            SubScribeFacade subScribeFacade = new SubScribeFacade(exChangesList, coinTypes);
            return subScribeFacade.GetAllPrice();
        });

            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MonitorsAsync();
        }

      
    }
}
