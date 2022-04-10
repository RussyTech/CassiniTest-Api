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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CassiniApiTestAutomation.StepDefinitions
{
    [Binding]
    public class RegisterSteps
    {
        private readonly ApiTestContext _apiTestContext;
        private RestResponse _restResponse;

        public RegisterSteps(ApiTestContext apiTestContext)
        {
            _apiTestContext = apiTestContext;
        }

        [Given(@"I perform a POST request to the ""(.*)"" endpoint with Table")]
        public async Task GivenIPerformAGETRequestForWithBody(string url, Table table)
        {
            _apiTestContext.SetBaseUrl();
            dynamic data = table.CreateDynamicInstance();
            _apiTestContext.AddRequest(url, Method.Post);
            _apiTestContext.Request.RequestFormat = DataFormat.Json;
            _apiTestContext.Request.AddBody(new {email = (string)data.Email, password = (string)data.Password});
            await _apiTestContext.GetResponse();
        }

        [Then (@"I should see the ""(.*)"" as ""(.*)""")]
        public void ThenIshouldSeeTheAs(string key, string value)
        {
            Assert.That(_apiTestContext.Response.GetResponseObject(key), Is.EqualTo(value), $"The {key} is not correct");
        }

        [Given(@"I perform a POST request to the ""(.*)"" endpoint with Jason data")]
        public async Task GivenIPerformAGETRequestForWithJsonData(string url)
        {
            _apiTestContext.SetBaseUrl();
            _apiTestContext.AddRequest(url, Method.Post);
            _apiTestContext.Request.RequestFormat = DataFormat.Json;
            var body = new post { Email = "eve.holt@reqres.in", Password = "pistol" };
            _apiTestContext.Request.AddBody(body);
            await _apiTestContext.GetResponse();
        }
        
        }
    }
}
