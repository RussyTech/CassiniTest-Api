using RestSharp;
using RestSharp.Authenticators;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using CassiniApiTestAutomation.Base;
using CassiniApiTestAutomation.Utilities;
using NUnit.Framework;

namespace CassiniApiTestAutomation.Hooks
{
    public  class Initialiser
    {
        private ApiTestContext _apiTestContext;
        private RestResponse _restResponse;

        public Initialiser(ApiTestContext apiTestContext)
        {
            _apiTestContext = apiTestContext;
        }

       /* [BeforeScenario]
        public void TestSetup()
        {
            _apiTestContext.BaseUrl = new Uri("https://reqres.in/api");
            _apiTestContext.RestClient.BaseUrl = _apiTestContext.BaseUrl;
        }*/
    }
}