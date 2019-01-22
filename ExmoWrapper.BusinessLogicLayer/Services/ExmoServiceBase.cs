using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExmoWrapper.BusinessLogicLayer.Services
{
    public abstract class ExmoServiceBase
    {
        protected static long _nounce;
        private string _key;
        private string _secret;
        private string _url = "http://api.exmo.com/v1/{0}";

        static ExmoServiceBase()
        {
            _nounce = GetTimestamp();
        }

        public ExmoServiceBase(string key, string secret)
        {
            this._key = key;
            this._secret = secret;
        }

        protected async Task<string> ApiQueryAsync(string apiName, IDictionary<string, string> dictioanry)
        {
            using (var client = new HttpClient())
            {
                var n = Interlocked.Increment(ref _nounce);
                dictioanry.Add("nonce", Convert.ToString(n));
                var message = ToQueryString(dictioanry);
                var sign = Sign(_secret, message);

                var content = new FormUrlEncodedContent(dictioanry);
                content.Headers.Add("Sign", sign);
                content.Headers.Add("Key", _key);

                var responce = await client.PostAsync(string.Format(_url, apiName), content);

                return await responce.Content.ReadAsStringAsync();
            }
        }

        private static long GetTimestamp()
        {
            var d = (DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds;
            return (long)d;
        }

        private string ToQueryString(IDictionary<string, string> dictioanry)
        {
            throw new NotImplementedException();
        }

        private static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary).ToLowerInvariant();
        }

        private static string Sign(string key, string message)
        {
            using (HMACSHA512 hmac = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
            {
                byte[] b = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                return ByteToString(b);
            }
        }
    }
}
