using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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

        public string EnKey = @"<RSAKeyValue><Modulus>zXRigE1lYYiyv6pin5nt7hxkHvbVg3kjzUQpgBN+SCqNZJ4cL03L5vo2F0/gqBds5Xq183SPbD5VD+EgRd8na1QvWypv9mjY2DHyNEBH8cndU3H5apFa3bsqa9PjupxeuGX1WLwOkkXqyoGWSoYvqlUAGIq+95/rglX3YVhX2iE=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        public string DeKey = @"<RSAKeyValue><Modulus>w5iT80FOe4jERmTYR2rejY1V+jFHE5Sxujoa3ApLe4becAeauEfCdyv1yfNxEtFQDchXUMg+3P7xGvtkt4f785toewkMhYsrCyXsxlR5JzbTUwFvhhZEgPQmcSSK3Ugk5LWE40AihXjeCJ2G8Z4M1Tb5s+38bxZTeu7ewyNWx2k=</Modulus><Exponent>AQAB</Exponent><P>4pBWslh0jE0glE13gaveLeNAUK/EoHQfWsz/BaANtkoaximJiJVwYdUj6CgSdrQ36xqVSBTdsSqaPkoSe3oCQw==</P><Q>3QI6u3hO2ZcTbjeSmJ92aDWxQ8glOmx0TEZ7I2PXyUxDjpdLue4XDDAoYTmY6JvBbOlJEAD1A1N+6BNCntDC4w==</Q><DP>omJJgTIc9qIhA6oySWJhsAn9Ate32jjgcDgVYHbC3TBn2DfVN2vETJpzTeXKtgGdQoifDjbGXkDmpFZ6wL1F+Q==</DP><DQ>UtVKFAeEbhMsiiuz+xYRN/+fv8rdASey8v+bmWkLcHvv+hqEnFw7MSs/hykiQVRXS62n36KsMiHyN6M4XfPahw==</DQ><InverseQ>jmMheMKz4hPCDwH6shYkzN03Zl6addC0nEbjJpnmhIq/Vq52Hj5ZpYQNFnVkyyLQDe452YvrRYCA6JMiWgTPKA==</InverseQ><D>ENwI/LHHYwyR5oNwxQ8oKclh/NPcjYqGm0fA4vCcOwSQDdYJ9xJwZ7dJU2QBfh6+qMF5DUSFbqUnAS1kLBGznNBXKvCvgPeXmJm7qlTVeE9UYWt0GGpiHaVEGjfqFVebOWgD3jTbTIiA0BLst5ZWzxjz1bo7C4W/T9NpnKN4/oU=</D></RSAKeyValue>";



        bool regflag = false;

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

            cpuid = Winner.Framework.Encrypt.MD5Provider.Encode(Winner.Framework.Utils.Computer.Instance.CPU_ID);

            this.lb_cpuid.Text = Winner.Framework.Encrypt.RSAProvider.Encrypt(cpuid, Encoding.UTF8, false, EnKey);

           // NoRes();




        }

        string script = @"var body=$(""body"");body.append('<div style=""position: absolute;top: 0;left: 0;z-index: 9999999;""><input type="""" style=""padding: 0;margin: 0;display:  block;width: 100px;height: 30px;float: left;""  name=""""  visible=""falase"" id=""buyamount""><button style=""width: 30px;height: 30px;border: none;background: green;padding: 0;margin: 0;display: block;float: left;""   onclick=""mybuybtn()"" id=""buybutton"">买</button><button style=""width: 30px;height: 30px;border: none;padding: 0;margin: 0;background: green;display: block;float: left;"" s onclick=""mysellbtn()""  id=""sellbutton"">卖</button><span style=""clear: both;""></span></div>');function mybuybtn(){$("".getCountCoinSJ"").val($(""#buyamount"").val());$("".transaction-buy-new"").eq(1).find("".first_tab_button"").click()}function mysellbtn(){$("".transaction-sell-new"").eq(1).find("".first_tab_button"").click()}setInterval(function(){var datad=$("".userOder-list tr.list-con"");for(var i=0;i<datad.length;i++){var tardom=datad[i];var tt=new Date($(tardom).html().substring(0,23).substring(4,100));var nnow=new Date();if(nnow.getTime()-tt.getTime()>30000){$("".cancel_Deal"",tardom).click()}}},60000);setInterval(function(){var tvalue=$("".baseCoin s"").html().split("" "")[0];var num=tvalue.indexOf(""."");if(num>0){tvalue=tvalue.substring(0,num+3)}$(""#getBaseCoin"").val(tvalue)},300)";


        int count = 0;
        int jiange = 0;
        decimal jine = 0;
        int cishu = 0;
        string cpuid;

      

        public void NoRes()
        {
            this.tb_cishu.Text = "10";
            this.tb_cishu.ReadOnly = true;
            this.tb_gedu.ReadOnly = true;
            this.tb_jiange.ReadOnly = true;
            regflag = false;
        }

        public void DoRes()
        {
            this.tb_cishu.Text = "500";
            this.tb_cishu.ReadOnly = false;
            this.tb_gedu.ReadOnly = false;
            this.tb_jiange.ReadOnly = false;
            regflag = true;
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
                regflag = false;
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



        private void btn_jihuo_Click(object sender, EventArgs e)
        {
            string enstr = this.tb_jihuo.Text;

            if (string.IsNullOrEmpty(enstr))
            {
                return;
            }

            string value = Winner.Framework.Encrypt.RSAProvider.Decrypt(enstr, Encoding.UTF8, false, DeKey);

            if (!cpuid.Equals(value))
            {
                NoRes();
            }
            else
            {
                DoRes();
            }
        }





        #region 读写config

        ///<summary> 
        ///返回*.exe.config文件中appSettings配置节的value项  
        ///</summary> 
        ///<param name="strKey"></param> 
        ///<returns></returns> 
        public static string GetAppConfig(string strKey)
        {
            string file = System.Windows.Forms.Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == strKey)
                {
                    return config.AppSettings.Settings[strKey].Value.ToString();
                }
            }
            return null;
        }

        ///<summary>  
        ///在*.exe.config文件中appSettings配置节增加一对键值对  
        ///</summary>  
        ///<param name="newKey"></param>  
        ///<param name="newValue"></param>  
        public static void UpdateAppConfig(string newKey, string newValue)
        {
            string file = System.Windows.Forms.Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            bool exist = false;
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == newKey)
                {
                    exist = true;
                }
            }
            if (exist)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            config.AppSettings.Settings.Add(newKey, newValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }


        #endregion

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
    }
}
