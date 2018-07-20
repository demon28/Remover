using Remover.DataAccess;
using Remover.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC.Controllers;
using Winner.Framework.Utils;

namespace Remover.WebApp.Controllers
{
    public class HomeController : TopControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListCurrency()
        {
            Tmp_QuotesCollection quotesCollection = new Tmp_QuotesCollection();
            Log.Info("---------调用查询开始-----------");
            quotesCollection.ListByCurrents();
            Log.Info("---------调用查询结束-----------");
            if (quotesCollection.Count==0)
            {
                SuccessResult(quotesCollection);
            }

            List<QuoteModel> ListQuote = MapProvider.Map<QuoteModel>(quotesCollection.DataTable);
            var k= ListQuote.GroupBy(t => t.PlatformName).Select(p => p.First()).ToList();

            //包装Title
            List<TitleVModel> titleList = new List<TitleVModel>();
            TitleVModel titleOn = new TitleVModel();
            titleOn.TitleName = "币种";
            titleList.Add(titleOn);
            foreach (var item in k)
            {
                TitleVModel title = new TitleVModel();
                title.TitleName = item.PlatformName;
                titleList.Add(title);
            }
            TitleVModel titleDiff = new TitleVModel();
            titleDiff.TitleName = "差值";
            titleList.Add(titleDiff);

            //包装统计值
            var q = from d in ListQuote
                    group d by d.CoinName into g
                    select new
                    {
                        MaxPrice = g.Max(x => x.SellPrice),
                        MinPrice = g.Min(t => t.BuyPrice),
                        coinName = g.Key
                    };

            //包装当前价格
            List<CoinInfoVModel> ListCoinInfo = new List<CoinInfoVModel>();
            foreach(var item in q)
            {
                CoinInfoVModel coinInfoVModel = new CoinInfoVModel();
                coinInfoVModel.CoinName = item.coinName;
                coinInfoVModel.Difference = item.MaxPrice - item.MinPrice;
                List<PriceVModel> ListPrice = new List<PriceVModel>();
                foreach (QuoteModel model in ListQuote)
                {
                    if(model.CoinName==item.coinName)
                    {
                        PriceVModel price = new PriceVModel();
                        price.BuyPrice = model.BuyPrice;
                        price.CoinName = model.CoinName;
                        price.SellPrice = model.SellPrice;
                        price.PlatformName = model.PlatformName;
                        price.Price = model.Price;
                        int isMaxAndMin = 0;
                        if(item.MaxPrice==model.SellPrice)
                        {
                            isMaxAndMin = 1;
                        }
                        if (item.MinPrice == model.BuyPrice)
                        {
                            isMaxAndMin = 2;
                        }
                        price.IsMaxAndMin = isMaxAndMin;
                        ListPrice.Add(price);
                    }
                }
                coinInfoVModel.PriceVModels = ListPrice;
                ListCoinInfo.Add(coinInfoVModel);
            }
            
            CoinPriceVModel tableModel = new CoinPriceVModel();
            tableModel.CoinInfoVModels = ListCoinInfo;
            tableModel.TitleVModels = titleList;
            return SuccessResult(tableModel);
        }
    }
}