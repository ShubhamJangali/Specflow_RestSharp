using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowExample.StepDefinitions
{
    [Binding]
    internal class Ops
    {
        RestClient client;
        RestRequest request;
        RestResponse response;
        [Given(@"the base URL is ""([^""]*)""")]
        public void GivenTheBaseURLIs(string url)
        {
            client = new RestClient(url);
            Console.WriteLine("Entered the Base Url");
        }

        [When(@"and the endpoint url is ""([^""]*)""")]
        public void WhenAndTheEndpointUrlIs(string endpoint)
        {
            request = new RestRequest(endpoint);
            Console.WriteLine("Entered the endpoint");
        }

        [When(@"perform get operation")]
        public void WhenPerformGetOperation()
        {
            response = client.Execute(request);
            Console.WriteLine("Performing GET operation");
        }

        [Then(@"print the response")]
        public void ThenPrintTheResponse()
        {
            var res = response.Content;
            Console.WriteLine(res);
            Console.WriteLine("Response is printed");
        }

    }
}
