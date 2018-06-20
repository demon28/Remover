using Remover.Entities;
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

            GetSingle();

        }


        private void GetSingle()
        {
           

          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            List<CoinType> coinTypes = new List<CoinType>();
            coinTypes.Add(CoinType.BTC);
            coinTypes.Add(CoinType.EOS);
            coinTypes.Add(CoinType.LTC);
            coinTypes.Add(CoinType.ETH);
            coinTypes.Add(CoinType.ETC);
       
            coinTypes.Add(CoinType.XRP);
            coinTypes.Add(CoinType.NEO);

            SubScribeFacade subScribeFacade = new SubScribeFacade(coinTypes);


            this.dataGridView1.DataSource = subScribeFacade.Enter();




            AutoSizeColumn(this.dataGridView1);


        }


        /// <summary>
        /// 使DataGridView的列自适应宽度
        /// </summary>
        /// <param name="dgViewFiles"></param>
        private void AutoSizeColumn(DataGridView dgViewFiles)
        {
            int width = 0;
            //使列自使用宽度
            //对于DataGridView的每一个列都调整
            for (int i = 0; i < dgViewFiles.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                dgViewFiles.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                //记录整个DataGridView的宽度
                width += dgViewFiles.Columns[i].Width;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > dgViewFiles.Size.Width)
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //冻结某列 从左开始 0，1，2
            dgViewFiles.Columns[1].Frozen = true;
        }
    }
}
