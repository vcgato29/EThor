using EThor.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EThor.DataAccess
{
    public class DataProvider : IDataProvider
    {
        private HttpClient httpClient;
        private string endPoint;
        public DataProvider()
        {
            httpClient = new HttpClient();
            endPoint = ConfigurationManager.AppSettings["EThorStatEndPoint"];
            if(string.IsNullOrEmpty(endPoint))
            {
                throw new ConfigurationErrorsException("EndPoint Not Found");
            }

        }

        public string Provide()
        {
            string jsonResponse = string.Empty;
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync(endPoint).Result;
            if (response.IsSuccessStatusCode)
            {
               jsonResponse =  response.Content.ReadAsStringAsync().Result;
            }
            return jsonResponse;
        }
    }
}
