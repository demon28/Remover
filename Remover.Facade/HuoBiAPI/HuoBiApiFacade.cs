using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Winner.Framework.Core.Facade;
using Remover.Entities;
using Winner.Framework.Utils;
using System.Net;

namespace Remover.Facade.HuoBiAPI
{
    public class HuoBiApiFacade:FacadeBase
    {


        #region HuoBiApi配置信息
        /// <summary>
        /// API域名名称
        /// </summary>
        private readonly string HUOBI_HOST = string.Empty;
        /// <summary>
        /// APi域名地址
        /// </summary>
        private readonly string HUOBI_HOST_URL = string.Empty;
        /// <summary>
        /// 加密方法
        /// </summary>
        private const string HUOBI_SIGNATURE_METHOD = "HmacSHA256";
        /// <summary>
        /// API版本
        /// </summary>
        private const int HUOBI_SIGNATURE_VERSION = 2;
        /// <summary>
        /// ACCESS_KEY
        /// </summary>
        private readonly string ACCESS_KEY = string.Empty;
        /// <summary>
        /// SECRET_KEY()
        /// </summary>
        private readonly string SECRET_KEY = string.Empty;
        #endregion

      

        #region 构造函数
        private RestClient client;//http请求客户端
        public HuoBiApiFacade(string accessKey, string secretKey, string huobi_host = "api.huobi.pro")
        {
            ACCESS_KEY = accessKey;
            SECRET_KEY = secretKey;
            HUOBI_HOST = huobi_host;
            HUOBI_HOST_URL = "https://" + HUOBI_HOST;
            if (string.IsNullOrEmpty(ACCESS_KEY))
                throw new ArgumentException("ACCESS_KEY Cannt Be Null Or Empty");
            if (string.IsNullOrEmpty(SECRET_KEY))
                throw new ArgumentException("SECRET_KEY  Cannt Be Null Or Empty");
            if (string.IsNullOrEmpty(HUOBI_HOST))
                throw new ArgumentException("HUOBI_HOST  Cannt Be Null Or Empty");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            client = new RestClient(HUOBI_HOST_URL);
            client.AddDefaultHeader("Content-Type", "application/json");
            client.AddDefaultHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36");
        }
        #endregion



        #region HTTP请求方法

        /// <summary>
        /// 发起Http请求Content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resourcePath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T SendRequestContent<T>(string resourcePath, string parameters = "") where T : new()
        {
            
            parameters = UrlHelper.UriEncodeParameterValue(GetCommonParameters() + parameters);//请求参数
            var sign = UrlHelper.GetSignatureStr(Method.GET, HUOBI_HOST, resourcePath, parameters,SECRET_KEY);//签名
            parameters += $"&Signature={sign}";

            var url = $"{HUOBI_HOST_URL}{resourcePath}?{parameters}";
   
            var request = new RestRequest(url, Method.GET);
            var result = client.Execute(request);
            client.Timeout = 5000;
            //Log.Debug($"HuoBi,statusCode={result.StatusCode};ErrorMessage={result.ErrorMessage};Content={result.Content}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Alert(result.ErrorMessage);
                return default(T);
            }

            if (result.Content==null||result.Content==string.Empty)
            {
                Alert(result.ErrorMessage);
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(result.Content);

        }



        #region 官网demo
        ///// <summary>
        ///// 发起Http请求
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="resourcePath"></param>
        ///// <param name="parameters"></param>
        ///// <returns></returns>
        //public HBResponse<T> SendRequest<T>(string resourcePath, string parameters = "") where T : new()
        //{
        //    parameters = UrlHelper.UriEncodeParameterValue(GetCommonParameters() + parameters);//请求参数
        //    var sign = UrlHelper.GetSignatureStr(Method.GET, HUOBI_HOST, resourcePath, parameters,SECRET_KEY);//签名
        //    parameters += $"&Signature={sign}";

        //    var url = $"{HUOBI_HOST_URL}{resourcePath}?{parameters}";
        //    Console.WriteLine(url);
        //    var request = new RestRequest(url, Method.GET);
        //    var result = client.Execute<HBResponse<T>>(request);
        //    return result.Data;
        //}
        ///// <summary>
        ///// 发起Http请求
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="P"></typeparam>
        ///// <param name="resourcePath"></param>
        ///// <param name="postParameters"></param>
        ///// <returns></returns>
        //public HBResponse<T> SendRequest<T, P>(string resourcePath, P postParameters) where T : new()
        //{
        //    var parameters = UrlHelper.UriEncodeParameterValue(GetCommonParameters());//请求参数
        //    var sign = UrlHelper.GetSignatureStr(Method.POST, HUOBI_HOST, resourcePath, parameters,SECRET_KEY);//签名
        //    parameters += $"&Signature={sign}";

        //    var url = $"{HUOBI_HOST_URL}{resourcePath}?{parameters}";
        //    Console.WriteLine(url);
        //    var request = new RestRequest(url, Method.POST);
        //    request.AddJsonBody(postParameters);
        //    foreach (var item in request.Parameters)
        //    {
        //        item.Value = item.Value.ToString().Replace("_", "-");
        //    }
        //    var result = client.Execute<HBResponse<T>>(request);
        //    return result.Data;
        //}


        #endregion

        /// <summary>
        /// 获取通用签名参数
        /// </summary>
        /// <returns></returns>
        public string GetCommonParameters()
        {
            return $"AccessKeyId={ACCESS_KEY}&SignatureMethod={HUOBI_SIGNATURE_METHOD}&SignatureVersion={HUOBI_SIGNATURE_VERSION}&Timestamp={DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")}";
        }
     
        #endregion
    }
}
