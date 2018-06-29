using Newtonsoft.Json;
using Remover.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;


namespace Remover.Facade.CoinealAPI
{
   public class CoinealAPIFacade : FacadeBase
    {

        public string HUOBI_HOST_URL, ApiKey, SecereKey;
        private RestClient client;

        public CoinealAPIFacade(string apikey, string secerekey, string url = "https://exchange-open-api.coineal.com")
        {
            HUOBI_HOST_URL = url;
            ApiKey = apikey;
            SecereKey = secerekey;
            client = new RestClient();
            client = new RestClient(HUOBI_HOST_URL);
            client.AddDefaultHeader("Content-Type", "application/json");
            client.AddDefaultHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36");
        }

        /// <summary>
        /// 无加密请求（适用获取行情）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resourcePath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T SendRequestContent<T>(string resourcePath, string parameters = "") where T : new()
        {

            var url = $"{HUOBI_HOST_URL}{resourcePath}?{parameters}";
     
            var request = new RestRequest(url, Method.GET);
            var result = client.Execute(request);
            if (result.Content == null || result.Content == string.Empty)
            {
                Alert(result.ErrorMessage);
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(result.Content);


        }


        /// <summary>
        /// 有加密请求（适用获取行情）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resourcePath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T EnSendRequestContent<T>(string resourcePath, Dictionary<string,string> parameters =null) where T : new()
        {

            var url = $"{HUOBI_HOST_URL}{resourcePath}?{GetSignString(GetCommonParameters(parameters))}";

            var request = new RestRequest(url, Method.GET);
            var result = client.Execute(request);
            if (result.Content == null || result.Content == string.Empty)
            {
                Alert(result.ErrorMessage);
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(result.Content);

        }


         public string GetSignString(string parameters) {

            string str = string.Empty;

            var sb = new StringBuilder();
            var paraArray = parameters.Split('&');
            var sortDic = new SortedDictionary<string, string>();
            foreach (var item in paraArray)
            {
                var para = item.Split('=');
                sortDic.Add(para.First(), para.Last());
                str += para.First()+para.Last();
            }
            foreach (var item in sortDic)
            {
                sb.Append(item.Key).Append("=").Append(item.Value).Append("&");
            }

            string sign= "sign=" + Winner.Framework.Encrypt.MD5Provider.Encode(str + SecereKey);

            return sb.ToString() + sign;


        }


        /// <summary>
        /// 获取通用签名参数
        /// </summary>
        /// <returns></returns>
        public string GetCommonParameters(Dictionary<string, string> parameters)
        {

            double timestamp = new Javirs.Common.TimeStamp();
            string unixtime= ((long)timestamp).ToString();

            string value=  $"api_key={ApiKey}&time={unixtime}";


            if (parameters==null)
            {
                return value;
            }

            foreach (var item in parameters)
            {
                value += "&" + item.Key + "=" + item.Value;
            }

            return value;
        }


    }
}
