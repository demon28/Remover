using Remover.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Remover.Entities.EnumType;

namespace Remover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExChangeBase exchange = ExchangeFactory.InstanExchange(ExchangeType.HuoBi);

            decimal t = exchange.GetSingleNowPrice(CoinType.EOS, CurrencyType.USDT);

            this.label1.Text = "火币网：" + t.ToString();




            ExChangeBase exchange2 = ExchangeFactory.InstanExchange(ExchangeType.OKEX);

            decimal o = exchange2.GetSingleNowPrice(CoinType.EOS, CurrencyType.USDT);

            this.label2.Text = "OKEX：" + o.ToString();
        }
    }
}
