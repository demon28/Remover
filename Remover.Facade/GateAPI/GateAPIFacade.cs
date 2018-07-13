using Newtonsoft.Json;
using Remover.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Core.Facade;
using Remover.Entities.GateRequestModel;
using Winner.Framework.Utils;

namespace Remover.Facade.GateAPI
{
    public  class GateAPIFacade: FacadeBase
    {

        public string HUOBI_HOST_URL, ApiKey, SecereKey;
        private RestClient client;

        public GateAPIFacade(string apikey,string secerekey,string url= "https://data.gateio.io")
        {
            HUOBI_HOST_URL = url;
            ApiKey = apikey;
            SecereKey = secerekey;
            client = new RestClient();
            client = new RestClient(HUOBI_HOST_URL);
            client.AddDefaultHeader("Content-Type", "application/x-www-form-urlencoded");
            client.AddDefaultHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36");
        }
        

        public T PostRequestContent<T>(string resourcePath, T model) where T : new()
        {
            //将所有参数做
            return JsonConvert.DeserializeObject<T>("");

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
            var url = $"{HUOBI_HOST_URL}{resourcePath}{parameters}";
        
            var request = new RestRequest(url, Method.GET);
            var result= client.Execute(request);
            client.Timeout = 5000;
            //Log.Debug($"GATE,statusCode={result.StatusCode};ErrorMessage={result.ErrorMessage};Content={result.Content}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Alert(result.ErrorMessage);
                return default(T);
            }
            if (result.Content == null || result.Content == string.Empty)
            {
                Alert(result.ErrorMessage);
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(result.Content);
        }

        /***
         * string[] parameters={"api_key=c821db84-6fbd-11e4-a9e3-c86000d26d7c","symbol=btc_usdt","type=buy","price=680","amount=1.0"};     
         * 首先比较所有参数名的第一个字母，按abcd顺序排列，若遇到相同首字母，则看第二个字母，以此类推；
         * amount=1.0&api_key=c821db84-6fbd-11e4-a9e3-c86000d26d7c&price=680&symbol=btc_usdt&type=buy
         * 然后，将待签名字符串添加私钥参数生成最终待签名字符串
         * amount=1.0&api_key=c821db84-6fbd-11e4-a9e3-c86000d26d7c&price=680&symbol=btc_usdt&type=buy&secret_key=secretKey
         * 注意，&secret_key=secretKey 为签名必传参数
         * 最后，是利用32位MD5算法，对最终待签名字符串进行签名运算，从而得到签名结果字符串(该字符串赋值于参数sign)，MD5计算结果中字母全部大写。 
         */

        private string ToSign(Dictionary<string, object> parameter)
        {
            string sign = string.Empty;
            var par = parameter.OrderBy(p => p.Key);
            foreach (var item in par)
            {
                sign += string.Format("{0}={1}&", item.Key, item.Value);
            }
            sign += "secret_key=" + SecereKey;
            sign = Winner.Framework.Encrypt.MD5Provider.Encode(sign).ToUpper();

            return sign;
        }


    }
}
