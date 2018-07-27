using Remover.DataAccess;
using Remover.Entities;
using Remover.Facade.WebScoketEvent;
using Remover.Facade.WebSocketAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remover.WinSocket
{
    public partial class form_SocketDepth : Form
    {
        public form_SocketDepth()
        {
            InitializeComponent();
        }
        
        private void btn_HuoBiStart_Click(object sender, EventArgs e)
        {
            //初始化WebSocket
            HuobiWSApi.Init();
            HuobiWSApi.OnMessage += HuobiWSApi_OnMessage;
            //查询数据库配置
            Vmp_ConfigCollection configColl = new Vmp_ConfigCollection();
            if (!configColl.ListByPlatformCode("HuoBi"))
            {
                return;
            }

            //订阅多个交易对深度
            foreach (Vmp_Config item in configColl)
            {
                string topic = StringProcess.HuoBiString(item.CurrencyCode, item.ExCurrencyCode);
                HuobiWSApi.Subscribe(topic, item.PairId.ToString());
            }
        }

        private void HuobiWSApi_OnMessage(object sender, HuoBiMessageReceivedEventArgs e)
        {
            HuoBiResponsePackage package = new HuoBiResponsePackage();
            package.MsgPackage(e.Message);
        }
        
        private void btn_OkStart_Click(object sender, EventArgs e)
        {

        }

        private void form_SocketDepth_FormClosing(object sender, FormClosingEventArgs e)
        {
            HuobiWSApi.OnClose();
        }
    }
}
