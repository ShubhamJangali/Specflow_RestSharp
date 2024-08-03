using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowExample
{
    [TestFixture]
    internal class nunit
    {
        [Test]
        public void add()
        {
            int a = 1;
            int b = 2;
            Console.WriteLine(a + b);
        }

        [Test]
        public void test()
        {
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("/api/users/2",Method.Get);
            var response = client.Post(request);
            var res = response.Content;
            Console.WriteLine(res);

        }

        [Test]
        public void postapi()
        {
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("/api/users", Method.Post);

            var body = new
            {
                name = "morpheus",
                job = "leader"
            };

            request.AddJsonBody(body);
            var response = client.Execute(request);
            var res = response.Content;

            var parsedJson = JToken.Parse(res);
            var formattedJson = parsedJson.ToString(Formatting.Indented);
            TestContext.WriteLine(formattedJson);

            var apiResponse = JsonConvert.DeserializeObject<User>(res);

            TestContext.WriteLine($"Name: {apiResponse.name}");
            TestContext.WriteLine($"Job: {apiResponse.job}");
            TestContext.WriteLine($"ID: {apiResponse.id}");
            TestContext.WriteLine($"Created At: {apiResponse.createdAt}");
        }

        [Test]
        public void putapi()
        {
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("/api/users/2", Method.Put);
            var body = new
            {
                name = "morpheus",
                job = "zion resident"
            };
            request.AddJsonBody(body);
            var response = client.Execute(request);
            var res = response.Content;
            Console.WriteLine(res);

            var apiresponse = JsonConvert.DeserializeObject<PUT>(res);

            Console.WriteLine(apiresponse.name);
            Console.WriteLine(apiresponse.job);
            Console.WriteLine(apiresponse.updatedAt);
        }

        [Test]
        public void deleteapi()
        {
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("/api/users/2", Method.Delete);
            var response = client.Execute(request);
            if(response.IsSuccessful)
            {
                Console.WriteLine(response.IsSuccessStatusCode);
            }
        }
    }

    public class User
    {
        public string name { get; set; }
        public string job { get; set; }
        public int id { get; set; }
        public string createdAt { get; set; }
    }

    class PUT
    {
        public string name { get; set; }
        public string job { get; set; }
        public string updatedAt { get; set; }
    }
}
