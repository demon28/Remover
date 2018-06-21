using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Remover.Entities;
using Remover.Entities.OKRequestModel;
using RestSharp;
using Winner.Framework.Core.Facade;

namespace Remover.Facade.OkExAPI
{
    class OkExAPIFacade:FacadeBase
    {


        private string ACCESS_KEY, SECRET_KEY;
        private RestClient client;
        public string  HOST_URL { get; private set; }
   

        public OkExAPIFacade(string accessKey, string secretKey, string okex_host = "https://www.okex.com")
        {
            ACCESS_KEY = accessKey;
            SECRET_KEY = secretKey;
            HOST_URL = okex_host;
        
            if (string.IsNullOrEmpty(ACCESS_KEY))
                throw new ArgumentException("ACCESS_KEY Cannt Be Null Or Empty");
            if (string.IsNullOrEmpty(SECRET_KEY))
                throw new ArgumentException("SECRET_KEY  Cannt Be Null Or Empty");
            if (string.IsNullOrEmpty(HOST_URL))
                throw new ArgumentException("HUOBI_HOST  Cannt Be Null Or Empty");
            client = new RestClient(HOST_URL);
            client.AddDefaultHeader("Content-Type", "application/json");
            client.AddDefaultHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36");

        }

   



        public T SendRequestContent<T>(string resourcePath, string parameters = "") where T : new()
        {
            var url = $"{HOST_URL}{resourcePath}?{parameters}";

            var request = new RestRequest(url, Method.GET);
            var result = client.Execute(request);
            if (result.Content == null || result.Content == string.Empty)
            {
                Alert(result.ErrorMessage);
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(result.Content);

        }


    }
}
