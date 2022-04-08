using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CassiniApiTestAutomation.Utilities;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace CassiniApiTestAutomation.Base
{
    public class ApiTestContext
    {
        public ApiTestContext()
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", false)
               .Build();

            BaseUrl = configuration["ApiConfiguration:BaseUrl"];
        }

        public RestResponse Response { get; private set; }
        public RestRequest Request { get; private set; }
        public RestClient RestClient { get; private set; }
        private string BaseUrl { get; }

        public void SetBaseUrl()
        {
            RestClient = new RestClient(BaseUrl);
        }

        //methods to handle request and response
        public void AddRequest(string resource, Method httpMethod)
        {
            Request = new RestRequest(resource, httpMethod);
        }

        public void AddRequestParameter(string name, object requestBody, ParameterType parameterType)
        {
            Request.AddOrUpdateParameter(name, requestBody, parameterType);
        }

        public void AddRequestParameter(string name, string requestBody)
        {
            Request.AddOrUpdateParameter(name, requestBody);
        }

        public void AddRequestHeader(string headerName, string headerValue)
        {
            Request.AddHeader(headerName, headerValue);
        }

        public async Task<RestResponse> GetResponse()
        {
            Response = await RestClient.ExecutePostAsync(Request);
            return Response;
        }

        public async Task<RestResponse> GetResponse<T>()
            where T : class, new()
        {
            Response = await RestClient.ExecuteAsyncRequest<T>(Request);
            return Response;
        }
    }
}
