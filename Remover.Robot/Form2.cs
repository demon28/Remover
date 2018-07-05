using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remover.Robot
{
    public partial class Form2 : Form
    {

        public ChromiumWebBrowser webBrowser;

        public Form2()
        {
            InitializeComponent();

            var setting = new CefSettings
            {

                Locale = "zh-CN",
                AcceptLanguageList = "zh-CN",
                MultiThreadedMessageLoop = true

            };

            Cef.Initialize(setting);
            webBrowser = new ChromiumWebBrowser("https://www.coineal.com/index.html#zh_CN");

            this.panel1.Controls.Add(webBrowser);
            webBrowser.Dock = DockStyle.Fill;
            
           
        }

        string script = @"var body=$(""body"");body.append('<div style=""position: absolute;top: 0;left: 0;z-index: 9999999;""><input type="""" style=""padding: 0;margin: 0;display:  block;width: 100px;height: 30px;float: left;""  name=""""  visible=""falase"" id=""buyamount""><button style=""width: 30px;height: 30px;border: none;background: green;padding: 0;margin: 0;display: block;float: left;""   onclick=""mybuybtn()"" id=""buybutton"">买</button><button style=""width: 30px;height: 30px;border: none;padding: 0;margin: 0;background: green;display: block;float: left;"" s onclick=""mysellbtn()""  id=""sellbutton"">卖</button><span style=""clear: both;""></span></div>');function mybuybtn(){$("".getCountCoinSJ"").val($(""#buyamount"").val());$("".transaction-buy-new"").eq(1).find("".first_tab_button"").click()}function mysellbtn(){$("".transaction-sell-new"").eq(1).find("".first_tab_button"").click()}setInterval(function(){var datad=$("".userOder-list tr.list-con"");for(var i=0;i<datad.length;i++){var tardom=datad[i];var tt=new Date($(tardom).html().substring(0,23).substring(4,100));var nnow=new Date();if(nnow.getTime()-tt.getTime()>30000){$("".cancel_Deal"",tardom).click()}}},60000);setInterval(function(){var tvalue=$("".baseCoin s"").html().split("" "")[0];var num=tvalue.indexOf(""."");if(num>0){tvalue=tvalue.substring(0,num+3)}$(""#getBaseCoin"").val(tvalue)},300)";


        int count = 0;
        int jiange = 0;
        decimal jine = 0;
        int cishu = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            var browser = webBrowser.GetBrowser().MainFrame;
     
            webBrowser.GetBrowser().MainFrame.ExecuteJavaScriptAsync(script);


            int.TryParse(tb_jiange.Text, out jiange);

            decimal.TryParse(tb_gedu.Text, out jine);

            int.TryParse(tb_cishu.Text, out cishu);

            string setvalue = @"$(""#buyamount"").val('" + jine + "')";

            webBrowser.GetBrowser().MainFrame.ExecuteJavaScriptAsync(setvalue);
        }

    
        private void button2_Click(object sender, EventArgs e)
        {
         
            this.timer1.Interval = jiange * 1000;
            this.timer1.Tick += Timer1_Tick;
            this.timer1.Start();
        }

        bool falg = true;

        private void Timer1_Tick(object sender, EventArgs e)
        {
            count = count + 1;
            this.label5.Text = count.ToString();

            if (count >= cishu)
            {
                this.timer1.Stop();
            }

            if (falg)
            {
                webBrowser.GetBrowser().MainFrame.ExecuteJavaScriptAsync("mybuybtn();");
                falg = false;
            }
            else
            {
                webBrowser.GetBrowser().MainFrame.ExecuteJavaScriptAsync("mysellbtn();");
                falg = true;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            count=0;
            this.timer1.Stop();
        }
    }
}
