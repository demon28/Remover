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
        public T SendRequestContent<T>(string resourcePath, string parameters = "") where T : class
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

        


    }
}
