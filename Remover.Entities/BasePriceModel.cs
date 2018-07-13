using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remover.Entities
{
    public class BasePriceModel
    {
        public decimal price { get; set; }

        public decimal buyPrice { get; set; }

        public decimal sellPice { get; set; }

        ///// <summary>
        ///// 当前价格
        ///// </summary>
        //private decimal _Price = decimal.Zero;
        //public decimal price
        //{
        //    get { return this.price; }
        //    set { this._Price = value; }
        //}
        ///// <summary>
        ///// 买一价
        ///// </summary>
        //private decimal _BuyPrice = decimal.Zero;
        //public decimal buyPrice
        //{
        //    get { return this.buyPrice; }
        //    set { this._BuyPrice = value; }
        //}
        ///// <summary>
        ///// 卖一价
        ///// </summary>
        //private decimal _SellPice = decimal.Zero;
        //public decimal sellPice
        //{
        //    get { return this.sellPice; }
        //    set { this._SellPice = value; }
        //}
    }
}
