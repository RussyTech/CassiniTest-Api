using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CassiniApiTestAutomation.Utilities
{
    public static class Helpers
    {
        public static string GetResponseObject(this RestResponse response, string responseObject)
        {
            var obs = JObject.Parse(response.Content);
            return obs[responseObject].ToString();
        }

        public static string GetResponseObjectArray(this RestResponse response, string responseObject)
        {
            // get the json array
            var arrResponse = JArray.Parse(response.Content);

            // parse through all the children
            foreach (var content in arrResponse.Children<JObject>())
            {
                // gets all the property(fields)
                foreach (var property in content.Properties())
                {
                    if (property.Name == responseObject)
                    {
                        // return the value
                        return property.Value.ToString();
                    }
                }
            }

            return string.Empty;
        }

        public static async Task<RestResponse> ExecuteAsyncRequest<T>(this RestClient client, RestRequest request)
            where T : class, new()
        {
            return await client.ExecuteAsync(request);
        }
    }
}
