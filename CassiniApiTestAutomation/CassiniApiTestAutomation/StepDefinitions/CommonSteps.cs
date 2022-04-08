using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using CassiniApiTestAutomation.Base;
using CassiniApiTestAutomation.Utilities;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using System.Diagnostics;

namespace CassiniApiTestAutomation.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        private readonly ApiTestContext _apiTestContext;
        private RestResponse _restResponse;

        public CommonSteps(ApiTestContext apiTestContext)
        {
            _apiTestContext = apiTestContext;
        }

        [Then(@"a ""(.*)"" response is returned")]
        //[Then(@"a (.*) response is returned")]
        public void ThenResponseIsReturned(int responseCode)
        {
            // get whole response
            var actResponse = _apiTestContext.Response;

            // assert that correct Status is returned
            var actStatusCode = (int)actResponse.StatusCode;
            Debug.WriteLine("Status description: " + actResponse.StatusDescription);
            Assert.AreEqual(responseCode, actStatusCode);
        }

    }
}
