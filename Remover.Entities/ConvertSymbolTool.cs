﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Remover.Entities.EnumType;

namespace Remover.Entities
{
   public static class ConvertSymbolTool
    {



        /// <summary>
        /// 币安可用, BTCUSDT 
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static string BiAnConvertSymbol(CoinType coin, CurrencyType currency)
        {
            return "&symbol=" + (coin.ToString() + currency.ToString()).ToUpper();
        }

        public static string BiAnConvertSymbol(string coinName,string currency)
        {
            return "&symbol=" + (coinName + currency).ToUpper();
        }



        /// <summary>
        /// 火币可用 btcusdt, bchbtc, rcneth 
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static string HBConvertSymbol(CoinType coin, CurrencyType currency)
        {
            return "&symbol=" + (coin.ToString() + currency.ToString()).ToLower();
        }

        public static string HBConvertSymbol(string coinName, string currency)
        {
            return "&symbol=" + (coinName + currency).ToLower();
        }

        /// <summary>
        ///  OKEx可用,GateIO可用 btc_usdt 
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static string OKConvertSymbol(CoinType coin, CurrencyType currency)
        {
            return "symbol="+(coin.ToString() + "_"+currency.ToString()).ToLower();
        }

        public static string OKConvertSymbol(string coinName, string currency)
        {
            return "symbol=" + (coinName + "_" + currency).ToLower();
        }


        /// <summary>
        ///  GateIO可用 btc_usdt 
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static string GateConvertSymbol(CoinType coin, CurrencyType currency)
        {
            return (coin.ToString() + "_" + currency.ToString()).ToLower();
        }

        public static string GateConvertSymbol(string coinName, string currency)
        {
            return (coinName + "_" + currency).ToLower();
        }

        /// <summary>
        ///  OKEx可用,GateIO可用 btc_usdt 
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static string ZBConvertSymbol(CoinType coin, CurrencyType currency)
        {
            return "market="+(coin.ToString() + "_" + currency.ToString()).ToLower();
        }

        public static string ZBConvertSymbol(string coinNam, string currency)
        {
            return "market=" + (coinNam + "_" + currency).ToLower();
        }
    }
}
